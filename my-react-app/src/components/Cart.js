// Оновлений код Cart
import React, { useState, useEffect } from 'react';
import { Button, Form, Modal } from 'react-bootstrap';
import { Link, useLocation } from 'react-router-dom';

const Cart = ({ onClose, onMyOrdersClick, selectedPizzas, setSelectedPizzas }) => {
  const cartHeight = 'calc(100% - 18.7vh)';
  const [toppings, setToppings] = useState([]);
  const [selectedToppings, setSelectedToppings] = useState({});
  const [totalPrice, setTotalPrice] = useState(0);
  const [showOrderModal, setShowOrderModal] = useState(false);
  const [customerName, setCustomerName] = useState("");
  const location = useLocation();
  const isMyOrdersPage = location.pathname === '/myorders'; 
  

  useEffect(() => {
    // Отримайте топінги з API
    fetch('https://localhost:7274/api/Topping')
      .then(response => response.json())
      .then(data => setToppings(data.$values))
      .catch(error => console.error('Error fetching toppings:', error));
  }, []);

  useEffect(() => {
    handleCalculatePrice();
  }, [selectedPizzas, selectedToppings]);

  const handleToppingChange = (pizzaIndex, toppingId) => {
    setSelectedToppings(prevState => ({
      ...prevState,
      [pizzaIndex]: {
        ...prevState[pizzaIndex],
        [toppingId]: !prevState[pizzaIndex]?.[toppingId]
      }
    }));
  };

  const handleRemovePizza = (pizzaIndex) => {
    setSelectedToppings(prevState => {
      const updatedState = { ...prevState };
      delete updatedState[pizzaIndex];
      return updatedState;
    });

    setSelectedPizzas(prevPizzas => {
      const updatedPizzas = [...prevPizzas];
      updatedPizzas.splice(pizzaIndex, 1);
      return updatedPizzas;
    });
  };


  function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
  }
  

  const handleCalculatePrice = () => {
    // Формуємо JSON для відправлення на сервер
    const orderData = selectedPizzas.map(({ pizzaSizeId }, index) => {
      const selectedPizzaToppings = Object.keys(selectedToppings?.[index] || {})
        .filter(toppingId => selectedToppings[index][toppingId])
        .map(Number);

      return {
        pizzaSizeId: pizzaSizeId + 1,
        pizzaOrderToppings: selectedPizzaToppings,
        customerName: "Lel"
      };
    });

    // Відправляємо дані на сервер
    fetch('https://localhost:7274/api/PizzaOrder', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(orderData),
    })
      .then(response => response.json())
      .then(data => {
        // Оновлюємо total price на отримане значення з сервера
        setTotalPrice(data);
        console.log('Server response:', data);
      })
      .catch(error => console.error('Error calculating price:', error));
  };

  const handleOrderButtonClick = () => {
    setShowOrderModal(true);
  };

  const handleOrderModalClose = () => {
    setShowOrderModal(false);
  };

 const handlePlaceOrder = () => {
  // Підготовка даних для замовлення
  const orderData = selectedPizzas.map(({ pizzaSizeId }, index) => {
    const selectedPizzaToppings = Object.keys(selectedToppings?.[index] || {})
      .filter((toppingId) => selectedToppings[index][toppingId])
      .map(Number);

    return {
      customerName: customerName,
      pizzaSizeId: pizzaSizeId + 1,
      pizzaOrderToppings: selectedPizzaToppings,
    };
  });

  // Відправляємо дані на сервер
  fetch('https://localhost:7274/api/SaveOrder', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(orderData),
  })
    .then((response) => response.json())
    .then((data) => {
      console.log('Order placed successfully:', data);
      // Додайте необхідну логіку для обробки успішного замовлення
    })
    .catch((error) => console.error('Error placing order:', error));

  // Зберігаємо замовлення та ціну в куках
  let ordersInCookie = JSON.parse(getCookie('orders') || '[]');
  if (!Array.isArray(ordersInCookie)) {
    ordersInCookie = [];
  }
  document.cookie = `orders=${JSON.stringify([...ordersInCookie, ...orderData])}; path=/`;

  // Зберігаємо ціну в куках
  document.cookie = `totalPrice=${totalPrice.toFixed(2)}; path=/`;

  console.log('Saved orders in cookies:', getCookie('orders'));
  console.log('Saved total price in cookies:', getCookie('totalPrice'));

  setShowOrderModal(false);
};

  return (
    <div className="cart bg-dark text-white" style={{ borderBottom: '8px solid #ccc', borderLeft: '8px solid #ccc', borderTop: '8px solid #ccc', paddingLeft: '10px', height: cartHeight, overflowY: 'auto', borderRadius: '0px 0px 0px 100px', display: 'flex', flexDirection: 'column' }}>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', padding: '10px' }}>
      <Link to="/myorders">
        <Button variant="light" style={{ width: '120px', marginBottom: '5px' }}>
          My Orders
        </Button>
        </Link>
        <Button variant="secondary" onClick={onClose} style={{ width: '120px' }}>
          Close cart
        </Button>
      </div>

      <div style={{ padding: '10px', flexGrow: 1 }}>
        <h4>Selected Pizzas:</h4>
        {selectedPizzas.length > 0 ? (
          <div className="d-flex flex-wrap">
            {selectedPizzas.map(({ image }, index) => (
              <div key={index} className="m-2">
                <img src={image} alt={`Selected Pizza ${index + 1}`} className="img-fluid" style={{ borderRadius: '10px' }} />
                
                <Form>
                  {toppings.map(topping => (
                    <Form.Check
                      key={topping.id}
                      type="checkbox"
                      label={topping.name}
                      checked={selectedToppings?.[index]?.[topping.id] || false}
                      onChange={() => handleToppingChange(index, topping.id)}
                    />
                  ))}
                </Form>

                <Button variant="danger" onClick={() => handleRemovePizza(index)} className="mt-2">
                  Remove Pizza
                </Button>
              </div>
            ))}
          </div>
        ) : (
          <p>No pizzas selected</p>
        )}
      </div>

      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', padding: '10px' }}>
        <p>Total Price: {totalPrice.toFixed(2)} €</p>
        <Button variant="success" onClick={handleOrderButtonClick} style={{ width: '120px' }}>
          Place Order
        </Button>
      </div>

      {/* Модальне вікно для замовлення */}
      <Modal show={showOrderModal} onHide={handleOrderModalClose}>
        <Modal.Header closeButton>
          <Modal.Title>Place Your Order</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form.Group>
            <Form.Label>Your Name:</Form.Label>
            <Form.Control
              type="text"
              value={customerName}
              onChange={(e) => setCustomerName(e.target.value)}
            />
          </Form.Group>
          <p>Total Price: {totalPrice.toFixed(2)} €</p>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleOrderModalClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handlePlaceOrder}>
            Place Order
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default Cart;

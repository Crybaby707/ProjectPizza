import React, { useState, useEffect } from 'react';
import "../MyOrders.css"; // Імпортуйте CSS файл

const MyOrders = () => {
  const [orders, setOrders] = useState([]);
  const [toppings, setToppings] = useState([]);
  const [totalCost, setTotalCost] = useState(0);

  // Мапа для відображення ідентифікаторів розмірів піци на їх назви
  const pizzaSizeNames = {
    1: 'Small',
    2: 'Medium',
    3: 'Large'
  };

  useEffect(() => {
    // Отримати замовлення з куків при завантаженні компоненту
    const ordersFromCookies = JSON.parse(getCookie('orders') || '[]');
    setOrders(ordersFromCookies);

    // Отримати топінги з API
    fetch('https://localhost:7274/api/Topping')
      .then(response => response.json())
      .then(data => setToppings(data.$values))
      .catch(error => console.error('Error fetching toppings:', error));

    // Отримати збережену ціну з куків
    const savedTotalCost = parseFloat(getCookie('totalPrice')) || 0;
    setTotalCost(savedTotalCost);
  }, []);

  // Функція для отримання значення з куків
  function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
  }

  // Функція для отримання назв топінгів по їхнім ідентифікаторам
  const getToppingNames = (toppingIds) => {
    return toppingIds.map(toppingId => toppings.find(topping => topping.id === toppingId)?.name || 'Unknown Topping');
  };

  return (
    <div className="orders-container">
      <h2>My Orders</h2>
      <p>Total Cost: {totalCost.toFixed(2)} €</p>
      {orders.length > 0 ? (
        <div className="orders-grid">
          {orders.map((order, index) => (
            <div key={index} className="order-card">
              <p>Order {index + 1}</p>
              <p>Customer Name: {order.customerName}</p>
              <p>Pizza Size: {pizzaSizeNames[order.pizzaSizeId]}</p>
              <p>Toppings: {getToppingNames(order.pizzaOrderToppings).join(', ')}</p>
              <p>Total Cost: {totalCost.toFixed(2)} €</p>
            </div>
          ))}
        </div>
      ) : (
        <p>No orders available</p>
      )}
    </div>
  );
};

export default MyOrders;

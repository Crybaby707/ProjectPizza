import React, { useState } from 'react';
import PizzaCard from './PizzaCard';
import Cart from './Cart';
import '../App.css';

const HomePage = ({ isCartOpen, setCartOpen }) => {
  const [selectedPizzas, setSelectedPizzas] = useState([]);

  const handlePizzaSelect = (pizzaData) => {
    setSelectedPizzas((prevSelectedPizzas) => [
      ...prevSelectedPizzas,
      { ...pizzaData },
    ]);
  };

  return (
    <div className="container mt-0 mb-0" style={{ height: '105vh' }}>
      <div className="d-flex justify-content-around">
        {[0, 1, 2].map((index) => (
          <PizzaCard key={index} pizzaIndex={index} onPizzaSelect={handlePizzaSelect} />
        ))}
      </div>
      {/* Викликаємо setCartOpen для відкриття/закриття Cart */}
      {isCartOpen && (
        <Cart
          onClose={() => setCartOpen(false)}
          onMyOrdersClick={() => setCartOpen(false)}
          selectedPizzas={selectedPizzas}
          setSelectedPizzas={setSelectedPizzas}
        />
      )}
    </div>
  );
};

export default HomePage;

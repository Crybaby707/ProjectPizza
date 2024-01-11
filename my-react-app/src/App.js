import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Header from './components/Header';
import HomePage from './components/HomePage';
import MyOrders from './components/MyOrders';
import Footer from './components/Footer';

function App() {
  const [isCartOpen, setCartOpen] = useState(false);

  const handleCartButtonClick = () => {
    setCartOpen(!isCartOpen);
  };

  const handleMyOrdersButtonClick = () => {
    console.log('Кнопка "My Orders" натиснута');
  };

  return (
    <Router>
      <div className="App">
        <Header onCartButtonClick={handleCartButtonClick} onMyOrdersButtonClick={handleMyOrdersButtonClick} />
        <Routes>
          <Route path="/myorders" element={<MyOrders />} />
          <Route path="/" element={<HomePage isCartOpen={isCartOpen} setCartOpen={setCartOpen} />} />
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

export default App;

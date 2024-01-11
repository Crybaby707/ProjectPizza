// Header.js
import React from 'react';
import { Button } from 'react-bootstrap';
import { Link, useLocation } from 'react-router-dom';

const Header = ({ onCartButtonClick }) => {
  const location = useLocation();
  const isMyOrdersPage = location.pathname === '/myorders'; // Опціонально: зміни шлях з '/my-orders' на '/myorders'

  return (
    <header className="bg-orange text-white p-3">
      <div className="container d-flex justify-content-between align-items-center">
        {/* Використовуйте Link для переходу на головну сторінку */}
        <Link to="/" style={{ textDecoration: 'none', color: 'white' }}>
          <h1 style={{ cursor: 'pointer' }}>Papa lolo</h1>
        </Link>
        <div>
          {/* Використовуйте Link для переходу на сторінку My Cart */}
          <Button variant="light" className="ml-2" onClick={onCartButtonClick} style={{ border: '5px solid #ccc', margin: "5px" }}>
            My Cart
          </Button>
          {/* Використовуйте Link для переходу на сторінку My Orders */}
          <Link to="/myorders">
            <Button variant={isMyOrdersPage ? "success" : "light"} className="ml-2" style={{ border: '5px solid #ccc', margin: "5px" }}>
              My Orders
            </Button>
          </Link>
        </div>
      </div>
    </header>
  );
};

export default Header;

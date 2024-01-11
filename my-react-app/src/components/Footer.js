import React from 'react';

const Footer = () => {
  return (
    <footer className="bg-dark text-white p-3 fixed-bottom" style={{ height: '18.7vh' }}>
      <div className="container">
        <div className="row">
          <div className="col-md-6">
            <h4>Contact us</h4>
            <p>Email: info@example.com</p>
            <p>Phone number: +1 123-456-7890</p>
          </div>
          <div className="col-md-6">
            <h4>Address</h4>
            <p>Somewhere in Poland</p>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;

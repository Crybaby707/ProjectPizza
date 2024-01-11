import React from 'react';

const PizzaCard = ({ pizzaIndex, onPizzaSelect }) => {
  const handleSelectButtonClick = () => {
    console.log(`Вибрано піцу ${pizzaIndex + 1}`);
    onPizzaSelect({
      pizzaSizeId: pizzaIndex,
      image: `https://141081297.cdn6.editmysite.com/uploads/1/4/1/0/141081297/s667510486388017382_p${pizzaIndex + 1}_i1_w1080.jpeg?width=2400&optimize=medium`,
    });
  };

  return (
    <div className="text-center">
      {/* Зображення піци */}
      <img
        src={`https://141081297.cdn6.editmysite.com/uploads/1/4/1/0/141081297/s667510486388017382_p${pizzaIndex + 1}_i1_w1080.jpeg?width=2400&optimize=medium`}
        alt={`Pizza ${pizzaIndex + 1}`}
        className="img-fluid"
      />
      <div className="mt-3">
        <button onClick={handleSelectButtonClick}>
          Вибрати
        </button>
      </div>
    </div>
  );
};

export default PizzaCard;

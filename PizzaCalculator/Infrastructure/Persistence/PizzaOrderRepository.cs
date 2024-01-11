using Microsoft.EntityFrameworkCore;
using PizzaCalculator.Domain;
using PizzaCalculator.Infrastructure.DTOs;
using PizzaCalculator.Infrastructure.Interfaces;

namespace PizzaCalculator.Infrastructure.Persistence
{
    public class PizzaOrderRepository : IPizzaOrderRepository
    {
        private readonly PizzaDbContext _dbContext;

        public PizzaOrderRepository(PizzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PizzaOrder GetOrderById(int orderId)
        {
            return _dbContext.PizzaOrders.Find(orderId);
        }

        public List<PizzaOrder> GetAllOrders()
        {
            return _dbContext.PizzaOrders
                .Include(order => order.PizzaSize)
                .Include(order => order.PizzaOrderToppings)
                    .ThenInclude(ot => ot.Topping)
                .ToList();
        }

        public decimal TotalCost(PizzaOrder order)
        {
            var pizzaSize = _dbContext.PizzaSizes.Find(order.PizzaSizeId);

            // Розрахувати вартість базової піци відповідно до розміру
            decimal baseCost = pizzaSize.Cost;
            decimal toppingsCost = 0;
            // Розрахувати вартість топінгів (кожен топінг коштує $1)
            if (order.PizzaOrderToppings != null)
            {

                toppingsCost = order.PizzaOrderToppings.Count * 1m;

                if (order.PizzaOrderToppings.Count > 3)
                {
                    toppingsCost *= 0.9m; // Знижка 10%
                }

            }


            // Застосувати знижку 10%, якщо обрано більше 3 топінгів


            // Розрахувати totalcost
            order.TotalCost = baseCost + toppingsCost;

            // Повернути вартість піци користувачеві
            return order.TotalCost;
        }

        public PizzaOrder SaveOrder(PizzaOrder order)
        {
            var pizzaSize = _dbContext.PizzaSizes.Find(order.PizzaSizeId);

            // Розрахувати вартість базової піци відповідно до розміру
            decimal baseCost = pizzaSize.Cost;
            decimal toppingsCost = 0;
            // Розрахувати вартість топінгів (кожен топінг коштує $1)
            if (order.PizzaOrderToppings != null)
            {

                toppingsCost = order.PizzaOrderToppings.Count * 1m;

                if (order.PizzaOrderToppings.Count > 3)
                {
                    toppingsCost *= 0.9m; // Знижка 10%
                }

            }

            // Розрахувати totalcost
            order.TotalCost = baseCost + toppingsCost;

            // Додати замовлення у базу даних
            _dbContext.PizzaOrders.Add(order);
            _dbContext.SaveChanges();

            return order;
        }
    }
}

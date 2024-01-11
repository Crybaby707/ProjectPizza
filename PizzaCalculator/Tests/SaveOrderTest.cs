using NSubstitute;
using PizzaCalculator.Domain;
using PizzaCalculator.Infrastructure.Interfaces;
using Xunit;

namespace PizzaCalculator.BL.Tests
{
    public class SaveOrderTest
    {
        private IPizzaOrderRepository _pizzaOrderRepository = Substitute.For<IPizzaOrderRepository>();

        [Fact]
        public void SaveOrder_SavesOrderCorrectly()
        {
            // Arrange
            var order = new PizzaOrder
            {
                CustomerName = "John",
                PizzaSizeId = 1,
                PizzaOrderToppings = new List<PizzaOrderTopping>
                {

                }
            };

            _pizzaOrderRepository.SaveOrder(order).Returns(order);

            // Act
            var savedOrder = _pizzaOrderRepository.SaveOrder(order);

            // Assert
            _pizzaOrderRepository.Received(1).SaveOrder(Arg.Any<PizzaOrder>());
            Assert.Equal(order.CustomerName, savedOrder.CustomerName);
            Assert.Equal(order.PizzaSizeId, savedOrder.PizzaSizeId);
            Assert.Equal(order.PizzaOrderToppings.Count, savedOrder.PizzaOrderToppings.Count);
            // Add more assertions as needed based on your specific requirements
        }
    }
}

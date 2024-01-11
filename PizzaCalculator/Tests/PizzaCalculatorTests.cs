using NSubstitute;
using PizzaCalculator.Domain;
using PizzaCalculator.Infrastructure.Interfaces;
using Xunit;

namespace PizzaCalculator.BL.Tests;

public class PizzaOrderBLTest
{
    private IPizzaOrderRepository _pizzaOrderRepository = Substitute.For<IPizzaOrderRepository>();

    [Fact]
    public void GetAll_ReturnsCorrectData()
    {
        //arrange
        var s = new List<PizzaOrder>
        {
            new PizzaOrder {
                Id = 1,
                CustomerName = "Vasyl",
                PizzaSizeId = 1,
                TotalCost = 10,
            },
            new PizzaOrder {
                Id = 2,
                CustomerName = "Vasyl",
                PizzaSizeId = 1,
                TotalCost = 15,
            }
        };

        _pizzaOrderRepository.GetAllOrders().Returns(s);

        //act
        var result = _pizzaOrderRepository.GetAllOrders();

        //assert
        Assert.Equal("Vasyl", result[0].CustomerName);
    }
}

using PizzaCalculator.Domain;

namespace PizzaCalculator.Infrastructure.Interfaces
{
    public interface IPizzaOrderRepository
    {
        PizzaOrder GetOrderById(int orderId);
        List<PizzaOrder> GetAllOrders();
        decimal TotalCost(PizzaOrder order);
        PizzaOrder SaveOrder(PizzaOrder order);
    }
}

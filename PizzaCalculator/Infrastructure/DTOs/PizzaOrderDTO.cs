using PizzaCalculator.Domain;

namespace PizzaCalculator.Infrastructure.DTOs
{
    public class PizzaOrderDTO
    {

        public string CustomerName { get; set; }
        public int PizzaSizeId { get; set; }
        public List<int> PizzaOrderToppings { get; set; }
    }
}

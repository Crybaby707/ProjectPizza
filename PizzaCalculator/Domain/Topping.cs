using System.ComponentModel.DataAnnotations;

namespace PizzaCalculator.Domain
{
    public class Topping
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public List<PizzaOrderTopping> PizzaOrderToppings { get; set; }

    }
}

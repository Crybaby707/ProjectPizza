using System.ComponentModel.DataAnnotations;

namespace PizzaCalculator.Domain
{
    public class PizzaOrderTopping
    {
        [Key]
        public int PizzaOrderToppingID {  get; set; } 
        public int PizzaOrderId { get; set; }
        public virtual PizzaOrder PizzaOrder { get; set; }
        public int ToppingId { get; set; }
        public virtual Topping Topping { get; set; }
    }
}

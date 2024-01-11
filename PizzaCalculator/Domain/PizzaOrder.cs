using System.ComponentModel.DataAnnotations;

namespace PizzaCalculator.Domain
{
    public class PizzaOrder
    {
        [Key]
        public int Id { get; set; }

        
        public string CustomerName { get; set; }

        public int PizzaSizeId { get; set; }

        public virtual PizzaSize PizzaSize { get; set; }

        public List<PizzaOrderTopping> PizzaOrderToppings { get; set; }

        public decimal TotalCost { get; set; }

    }
}

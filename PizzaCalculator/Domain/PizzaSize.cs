using System.ComponentModel.DataAnnotations;

namespace PizzaCalculator.Domain
{
    public class PizzaSize
    {
        [Key]
        public int Id { get; set; }
        public string SizeName { get; set; }
        public decimal Cost { get; set; }
    }
}

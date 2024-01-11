using PizzaCalculator.Domain;

namespace PizzaCalculator.Infrastructure.Interfaces
{
    public interface IToppingRepository
    {
        public List<Topping> GetAllToppings();

    }
}
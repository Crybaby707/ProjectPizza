using PizzaCalculator.Domain;

namespace PizzaCalculator.Infrastructure.Interfaces
{
    public interface IPizzaSizeRepository
    {
        PizzaSize GetPizzaSizeById(int pizzaSizeId);
    }
}

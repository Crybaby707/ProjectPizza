using Microsoft.EntityFrameworkCore;
using PizzaCalculator.Domain;
using PizzaCalculator.Infrastructure.Interfaces;

namespace PizzaCalculator.Infrastructure.Persistence
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly PizzaDbContext _dbContext;

        public ToppingRepository(PizzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Topping> GetAllToppings()
        {
            return _dbContext.Toppings
                .ToList();
        }

    }
}

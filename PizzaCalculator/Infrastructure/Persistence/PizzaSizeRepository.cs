using PizzaCalculator.Domain;
using PizzaCalculator.Infrastructure.Interfaces;

namespace PizzaCalculator.Infrastructure.Persistence
{
    public class PizzaSizeRepository : IPizzaSizeRepository
    {

        private readonly PizzaDbContext _dbContext;

        public PizzaSizeRepository(PizzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PizzaSize GetPizzaSizeById(int pizzaSizeId)
        {
            return _dbContext.PizzaSizes.Find(pizzaSizeId);
        }

    }
}

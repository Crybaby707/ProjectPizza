using Microsoft.AspNetCore.Mvc;
using PizzaCalculator.Domain;
using PizzaCalculator.Infrastructure.Interfaces;
using PizzaCalculator.Infrastructure.Persistence;

namespace PizzaCalculator.Infrastructure.Web
{

    [ApiController]
    [Route("api/[controller]")]
    public class ToppingController : ControllerBase
    {
        private readonly IToppingRepository _toppingRepository;
        public ToppingController(IToppingRepository toppingRepository)
        {
            _toppingRepository = toppingRepository;
        }


        // GET: api/<Topping>
        [HttpGet]
        public IEnumerable<Topping> Get()
        {

            return _toppingRepository.GetAllToppings();
        }

    }



}

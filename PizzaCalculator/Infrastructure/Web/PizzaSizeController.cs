using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaCalculator.Domain;
using PizzaCalculator.Infrastructure.Interfaces;
using PizzaCalculator.Infrastructure.Persistence;

namespace PizzaCalculator.Infrastructure.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaSizeController  : ControllerBase
    {

        private readonly IPizzaSizeRepository _pizzaSizeRepository;

        public PizzaSizeController(IPizzaSizeRepository pizzaSizeRepository)
        {
            _pizzaSizeRepository = pizzaSizeRepository;
        }

        // GET: api/<PizzaSize/5>
        [HttpGet("{pizzaSizeId}")]
        public PizzaSize GetPizzaSizeById(int pizzaSizeId)
        {
            return _pizzaSizeRepository.GetPizzaSizeById(pizzaSizeId);
        }



    }

}

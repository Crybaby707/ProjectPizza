using Microsoft.AspNetCore.Mvc;
using PizzaCalculator.Domain;
using PizzaCalculator.Infrastructure.DTOs;
using PizzaCalculator.Infrastructure.Interfaces;

namespace PizzaCalculator.Infrastructure.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaOrderController : ControllerBase
    {
        private readonly IPizzaOrderRepository _orderRepository;

        public PizzaOrderController(IPizzaOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/<PizzaOrder>
        [HttpGet]
        public IEnumerable<PizzaOrder> Get()
        {

            return _orderRepository.GetAllOrders();
        }

        // GET api/<GenreController>/5
        [HttpGet("{orderId}")]
        public PizzaOrder GetGenreById(int orderId)
        {
            return _orderRepository.GetOrderById(orderId);
        }

        [HttpPost]
        public decimal Post([FromBody] List<PizzaOrderDTO> pizzaOrdersDTO)
        {
            List<decimal> totalCosts = new List<decimal>();
            string customerName = "JohnSnow";

            foreach (var pizzaOrderDTO in pizzaOrdersDTO)
            {
                var pizzaOrder = new PizzaOrder
                {
                    CustomerName = customerName,
                    PizzaSizeId = pizzaOrderDTO.PizzaSizeId
                };

                if (pizzaOrderDTO.PizzaOrderToppings != null && pizzaOrderDTO.PizzaOrderToppings.Any())
                {
                    pizzaOrder.PizzaOrderToppings = pizzaOrderDTO.PizzaOrderToppings
                        .Select(toppingId => new PizzaOrderTopping { ToppingId = toppingId })
                        .ToList();
                }

                totalCosts.Add(_orderRepository.TotalCost(pizzaOrder));
            }

            return totalCosts.Sum();
        }

    }
}

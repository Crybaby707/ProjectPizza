using Microsoft.AspNetCore.Mvc;
using PizzaCalculator.Domain;
using PizzaCalculator.Infrastructure.DTOs;
using PizzaCalculator.Infrastructure.Interfaces;

namespace PizzaCalculator.Infrastructure.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaveOrderController : ControllerBase
    {
        private readonly IPizzaOrderRepository _orderRepository;

        public SaveOrderController(IPizzaOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // POST api/<GenreController>
        [HttpPost]
        public List<PizzaOrder> Post([FromBody] List<PizzaOrderDTO> pizzaOrdersDTO)
        {
            List<PizzaOrder> savedOrders = new List<PizzaOrder>();

            foreach (var pizzaOrderDTO in pizzaOrdersDTO)
            {
                var pizzaOrder = new PizzaOrder
                {
                    CustomerName = pizzaOrderDTO.CustomerName,
                    PizzaSizeId = pizzaOrderDTO.PizzaSizeId
                };

                if (pizzaOrderDTO.PizzaOrderToppings != null && pizzaOrderDTO.PizzaOrderToppings.Any())
                {
                    pizzaOrder.PizzaOrderToppings = pizzaOrderDTO.PizzaOrderToppings
                        .Select(toppingId => new PizzaOrderTopping { ToppingId = toppingId })
                        .ToList();
                }

                var savedOrder = _orderRepository.SaveOrder(pizzaOrder);
                savedOrders.Add(savedOrder);
            }

            return savedOrders;
        }
    }
}

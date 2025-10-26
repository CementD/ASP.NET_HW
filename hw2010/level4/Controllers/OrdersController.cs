using AutoMapper;
using level4.DTO;
using level4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace level4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        public OrdersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("orders")]
        public IActionResult GetOrders()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    OrderId = 1,
                    User = new User { Name = "John" },
                    Items = new List<OrderItem>
                    {
                        new() { ProductName = "Laptop", Quantity = 1 },
                        new() { ProductName = "Mouse", Quantity = 2 }
                    }
                }
            };

            var dtoList = _mapper.Map<List<OrderDto>>(orders);
            return Ok(dtoList);
        }
    }
}

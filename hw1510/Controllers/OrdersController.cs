using Microsoft.AspNetCore.Mvc;

namespace hw1510.Controllers
{
    [ApiController]
    [Route("api/shops/{shopId}/users/{userId}/orders")]
    public class OrdersController : ControllerBase
    {
        // GET /api/shops/{shopId}/users/{userId}/orders/{orderId}?includeDetails=true
        [HttpGet("{orderId}")]
        public IActionResult GetOrder(
            [FromRoute] int shopId,
            [FromRoute] int userId,
            [FromRoute] int orderId,
            [FromQuery] bool includeDetails = false)
        {
            var result = new
            {
                ShopId = shopId,
                UserId = userId,
                OrderId = orderId,
                IncludeDetails = includeDetails,
                Message = "Order retrieved successfully"
            };
            return Ok(result);
        }
    }
}

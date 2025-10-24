using Microsoft.AspNetCore.Mvc;

namespace YourApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // GET /api/products/{categoryId}/{productId}
        [HttpGet("{categoryId}/{productId}")]
        public IActionResult GetProduct([FromRoute] int categoryId, [FromRoute] int productId)
        {
            var result = new
            {
                CategoryId = categoryId,
                ProductId = productId,
                Message = "Product retrieved successfully"
            };
            return Ok(result);
        }

        // GET /api/products/search?name=...&minPrice=...
        [HttpGet("search")]
        public IActionResult SearchProducts([FromQuery] string name, [FromQuery] decimal? minPrice)
        {
            var result = new
            {
                Name = name,
                MinPrice = minPrice,
                Message = "Search results returned"
            };
            return Ok(result);
        }

        // POST /api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] object product)
        {
            return Created("", new
            {
                Product = product,
                Message = "Product created successfully"
            });
        }
    }
}

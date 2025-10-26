using hw1810.DTO;
using hw1810.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hw1810.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Description = "Gaming laptop", Price = 1200, Quantity = 5 },
            new Product { Id = 2, Name = "Phone", Description = "Smartphone", Price = 800, Quantity = 10 },
            new Product { Id = 3, Name = "Headphones", Description = "Wireless", Price = 150, Quantity = 20 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAll(
            [FromQuery] string? name,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] string? sortBy)
        {
            var query = _products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            query = sortBy?.ToLower() switch
            {
                "price" => query.OrderBy(p => p.Price),
                "name" => query.OrderBy(p => p.Name),
                _ => query.OrderBy(p => p.Id)
            };

            var result = query.Select(p => new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound(new { message = $"Product with id {id} not found" });

            return Ok(new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            });
        }

        [HttpPost]
        public ActionResult<ProductReadDto> Create([FromBody] ProductCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Product
            {
                Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Quantity = dto.Quantity
            };

            _products.Add(product);

            var result = new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            };

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound(new { message = $"Product with id {id} not found" });

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;

            return Ok(new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound(new { message = $"Product with id {id} not found" });

            _products.Remove(product);
            return Ok(new { message = "Product deleted successfully" });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Models.Product> Products = new()
        {
            new Models.Product { Id = 1, Name = "IPhone 17", Price = 80000 },
            new Models.Product { Id = 2, Name = "IPhone 16", Price = 39000 },
            new Models.Product { Id = 3, Name = "IPhone 15", Price = 29000 }
        };
        [HttpGet]// api/products GET
        public ActionResult<IEnumerable<Models.Product>> GetProducts()
        {
            return Ok(Products);
        }
        [HttpGet("{id}")] // api/products/1 GET show 
        public ActionResult<Models.Product> GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]// api/products POST create 
        public ActionResult<Models.Product> CreateProduct(Models.Product product)
        {
            product.Id = Products.Max(p => p.Id) + 1;
            Products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        [HttpPut("{id}")] // api/products/1 PUT update
        public IActionResult UpdateProduct(int id, Models.Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return NoContent();
        }
        [HttpDelete("{id}")] // api/products/1 DELETE delete
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            Products.Remove(product);
            return NoContent();
        }
    }
}
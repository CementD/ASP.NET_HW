using Microsoft.AspNetCore.Mvc;
using WebApplication2209.Models;

namespace WebApplication2209.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99M },
            new Product { Id = 2, Name = "Smartphone", Price = 499.99M },
            new Product { Id = 3, Name = "Tablet", Price = 299.99M }
        };
        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product) {
            if (ModelState.IsValid) {
                product.Id = products.Max(p => p.Id) + 1;
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        
        public IActionResult Show(int id) {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) {
                return NotFound();
            }
            return View(product);
        }


        public IActionResult Edit(int id) {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product, string metod) {
            if (!ModelState.IsValid) {
                return View(product);
            }
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null) {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            return RedirectToAction("Index");
        }
    }
}

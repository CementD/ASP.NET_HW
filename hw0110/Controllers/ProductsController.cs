using hw0110.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw0110.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 25000 },
            new Product { Id = 2, Name = "Smartphone", Price = 18000 },
            new Product { Id = 3, Name = "Headphones", Price = 1200 }
        };
        public IActionResult Index()
        {
            ViewBag.Info = "Product list";
            return View(_products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            product.Id = _products.Count + 1;
            _products.Add(product);
            return RedirectToAction("Index");
        }
    }
}

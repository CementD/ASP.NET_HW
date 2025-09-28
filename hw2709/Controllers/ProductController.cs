using hw2709.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2709.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            return Content($"Product created: {product.Name}, price: {product.Price}");
        }
    }
}

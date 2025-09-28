using hw2409.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2409.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                return View("Details", product);
            }
            return View(product);
        }
    }
}

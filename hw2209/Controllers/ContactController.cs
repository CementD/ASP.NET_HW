using hw2209.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2209.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit(ContactForm form)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", form);
            }
            return View("Result", form);
        }
    }
}

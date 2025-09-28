using hw2709.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2709.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegistration);
            }
            return Content("Registration successful!");
        }
    }
}

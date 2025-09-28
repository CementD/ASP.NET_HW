using hw2409.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2409.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                return View("Success");
            }
            return View(user);
        }
    }
}

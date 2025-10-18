using Microsoft.AspNetCore.Mvc;
using SmartTrip.Models;

namespace SmartTrip.Controllers
{
    public class AccountController : Controller
    {
        private static readonly List<User> _users = new()
        {
            new User { Id = 1, Email = "admin@smarttrip.com", Password = "admin123", Role = Role.Admin }
        };

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }

            HttpContext.Session.SetString("Role", user.Role.ToString());
            TempData["Success"] = $"Welcome, {user.Role}!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

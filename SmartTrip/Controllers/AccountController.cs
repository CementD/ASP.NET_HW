using Microsoft.AspNetCore.Mvc;
using SmartTrip.Data;
using SmartTrip.Models;

namespace SmartTrip.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // --- REGISTER ---
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool exists = _context.Users.Any(u => u.Email == model.Email);
            if (exists)
            {
                ModelState.AddModelError("Email", "Цей email вже зареєстровано.");
                return View(model);
            }

            model.Role = Role.Customer;
            _context.Users.Add(model);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Реєстрація успішна! Тепер ви можете увійти.";
            return RedirectToAction("Login");
        }

        // --- LOGIN ---
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Email == email && u.Password == password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Невірний email або пароль.");
                return View();
            }

            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.Role.ToString());

            TempData["Success"] = $"Ласкаво просимо, {user.Email}!";
            return RedirectToAction("Index", "Home");
        }

        // --- LOGOUT ---
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Success"] = "Ви вийшли з облікового запису.";
            return RedirectToAction("Index", "Home");
        }
    }
}

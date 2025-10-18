using hw0810.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw0810.Controllers
{
    public class UsersController : Controller
    {
        private static List<User> _users = new()
        {
            new User{ Id=1, Name="Alice", Email="alice@example.com", Password="pwd", Role=Role.User },
            new User{ Id=2, Name="Admin", Email="admin@example.com", Password="admin", Role=Role.Admin }
        };

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var u = _users.FirstOrDefault(x => x.Id == id);
            if (u == null) return NotFound();
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User model)
        {
            if (!ModelState.IsValid) return View(model);
            var u = _users.FirstOrDefault(x => x.Id == model.Id);
            if (u == null) return NotFound();
            u.Name = model.Name;
            u.Email = model.Email;
            TempData["Success"] = "User updated";
            return RedirectToAction("Edit", new { id = u.Id });
        }
    }
}

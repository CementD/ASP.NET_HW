using hw2709.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2709.Controllers
{
    public class EventController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(EventRegistration eventRegistration)
        {
            if (!ModelState.IsValid)
            {
                return View(eventRegistration);
            }
            return Content($"Participant: {eventRegistration.FirstName} {eventRegistration.LastName}, {eventRegistration.Age} years old");
        }
    }
}

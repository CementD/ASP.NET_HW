using hw2709.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2709.Controllers
{
    public class AppointmentController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (!ModelState.IsValid) { 
                return View(appointment);
            }
            return Content($"Appointment {appointment.Title} scheduled for {appointment.Date.ToShortDateString()}");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SmartTrip.Models;
using SmartTrip.Services.Interfaces;

namespace SmartTrip.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IEmailService _emailService;

        public BookingsController(ITourService tourService, IEmailService emailService)
        {
            _tourService = tourService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Book(int tourId)
        {
            var tour = await _tourService.GetByIdAsync(tourId);
            if (tour == null) return NotFound();
            var booking = new Booking { TourId = tourId };
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Book(Booking model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _tourService.BookAsync(model);
            if (!result)
            {
                ModelState.AddModelError("", "Not enough seats or duplicate email.");
                return View(model);
            }

            await _emailService.SendConfirmationAsync(model.Email, model.CustomerName);
            TempData["Success"] = "Booking confirmed!";
            return RedirectToAction("Index", "Home");
        }
    }
}

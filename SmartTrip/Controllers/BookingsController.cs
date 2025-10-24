using Microsoft.AspNetCore.Mvc;
using SmartTrip.Data;
using SmartTrip.Models;
using SmartTrip.Services.Interfaces;

namespace SmartTrip.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IEmailService _emailService;
        private readonly AppDbContext _context;

        public BookingsController(ITourService tourService, IEmailService emailService, AppDbContext context)
        {
            _tourService = tourService;
            _emailService = emailService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int tourId)
        {
            var tour = await _context.Tours.FindAsync(tourId);
            if (tour == null) return NotFound();

            ViewBag.Tour = tour;
            return View(new Booking());
        }

        [HttpPost]
        public async Task<IActionResult> Create(int tourId, Booking booking)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tour = await _context.Tours.FindAsync(tourId);
                return View(booking);
            }

            var success = await _tourService.BookTourAsync(tourId, booking);
            if (!success)
            {
                ModelState.AddModelError("", "Неможливо забронювати: або місць нема, або email вже використано.");
                ViewBag.Tour = await _context.Tours.FindAsync(tourId);
                return View(booking);
            }

            await _emailService.SendBookingConfirmationAsync(booking.Email, booking.Tour?.Name ?? "Tour");
            TempData["Success"] = "Бронювання успішне! Підтвердження відправлено на email.";

            return RedirectToAction("Confirm", new { id = booking.Id });
        }

        public async Task<IActionResult> Confirm(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            return View(booking);
        }
    }
}

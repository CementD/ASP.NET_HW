using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTrip.Data;
using SmartTrip.Models;

namespace SmartTrip.Controllers
{
    public class ToursController : Controller
    {
        private readonly AppDbContext _context;

        public ToursController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _context.Tours.Include(t => t.Destination).ToListAsync();
            return View(tours);
        }

        public IActionResult Create()
        {
            ViewBag.Destinations = _context.Destinations.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tour tour)
        {
            if (tour.StartDate < DateTime.Today)
                ModelState.AddModelError("StartDate", "Дата початку не може бути у минулому.");

            if (!ModelState.IsValid)
            {
                ViewBag.Destinations = _context.Destinations.ToList();
                return View(tour);
            }

            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Тур створено!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null) return NotFound();

            ViewBag.Destinations = _context.Destinations.ToList();
            return View(tour);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tour tour)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Destinations = _context.Destinations.ToList();
                return View(tour);
            }

            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Зміни збережено.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null) return NotFound();

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Тур видалено.";
            return RedirectToAction(nameof(Index));
        }
    }
}

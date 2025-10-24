using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTrip.Data;
using SmartTrip.Models;

namespace SmartTrip.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly AppDbContext _context;

        public DestinationsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var destinations = await _context.Destinations.ToListAsync();
            return View(destinations);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Destination destination)
        {
            if (!ModelState.IsValid)
                return View(destination);

            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Напрямок додано!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dest = await _context.Destinations.FindAsync(id);
            if (dest == null) return NotFound();
            return View(dest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Destination destination)
        {
            if (!ModelState.IsValid)
                return View(destination);

            _context.Destinations.Update(destination);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Зміни збережено.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dest = await _context.Destinations.FindAsync(id);
            if (dest == null) return NotFound();

            _context.Destinations.Remove(dest);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Напрямок видалено.";
            return RedirectToAction(nameof(Index));
        }
    }
}

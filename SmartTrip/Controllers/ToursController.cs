using Microsoft.AspNetCore.Mvc;
using SmartTrip.Models;
using SmartTrip.Services.Interfaces;

namespace SmartTrip.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourService _tourService;

        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllAsync();
            return View(tours);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Tour model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _tourService.AddAsync(model);
            TempData["Success"] = "Tour created successfully!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tour = await _tourService.GetByIdAsync(id);
            if (tour == null) return NotFound();
            return View(tour);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tour model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _tourService.UpdateAsync(model);
            TempData["Success"] = "Tour updated!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _tourService.DeleteAsync(id);
            TempData["Success"] = "Tour deleted!";
            return RedirectToAction(nameof(Index));
        }
    }
}

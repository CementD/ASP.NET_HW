using Microsoft.AspNetCore.Mvc;
using SmartTrip.Models;

namespace SmartTrip.Controllers
{
    public class DestinationsController : Controller
    {
        private static readonly List<Destination> _destinations = new();

        public IActionResult Index() => View(_destinations);

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Destination model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Id = _destinations.Count + 1;
            _destinations.Add(model);
            TempData["Success"] = "Destination added successfully!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _destinations.FirstOrDefault(d => d.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Destination model)
        {
            var item = _destinations.FirstOrDefault(d => d.Id == model.Id);
            if (item == null) return NotFound();

            item.Name = model.Name;
            item.Country = model.Country;
            item.Description = model.Description;
            item.ImageUrl = model.ImageUrl;

            TempData["Success"] = "Destination updated!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = _destinations.FirstOrDefault(d => d.Id == id);
            if (item != null) _destinations.Remove(item);
            TempData["Success"] = "Destination deleted!";
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTripApp.Data;
using SmartTripApp.Models;
using SmartTripApp.Repositories;
using SmartTripApp.Services;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace SmartTripApp.Controllers
{
    public class DestinationController : Controller
    {
        private readonly DestinationRepository _destinationRepository;

        public DestinationController(DestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            IEnumerable<Destination> destinations = await _destinationRepository.GetAllAsync();
            return View(destinations);
        }

        [Authorize]
        public ActionResult Create()
        {
            var newDestination = new Destination();
            ViewBag.Countries = Enum.GetValues(typeof(Country)).Cast<Country>();
            return View(newDestination);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Destination newDestination)
        {
            ModelState.Remove("Tours");
            if (!ModelState.IsValid)
            {
                ViewBag.Countries = Enum.GetValues(typeof(Country)).Cast<Country>();
                return View(newDestination);
            }

            await _destinationRepository.AddAsync(newDestination);
            await _destinationRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            Destination? destination = await _destinationRepository.GetByIdAsync(id);
            if (destination == null)
            {
                return NotFound();
            }

            ViewBag.Countries = Enum.GetValues(typeof(Country)).Cast<Country>();
            return View(destination);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Destination destination)
        {
            ModelState.Remove("Tours");
            if (!ModelState.IsValid)
            {
                ViewBag.Countries = Enum.GetValues(typeof(Country)).Cast<Country>();
                return View(destination);
            }

            await _destinationRepository.UpdateAsync(destination);
            await _destinationRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            Destination? destination = await _destinationRepository.GetByIdAsync(id);
            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, IFormCollection collection)
        {
            Destination? destination = await _destinationRepository.GetByIdAsync(id);
            if (destination == null)
            {
                return NotFound();
            }

            await _destinationRepository.DeleteAsync(id);
            await _destinationRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartTripApp.Models;
using SmartTripApp.Repositories;
using SmartTripApp.Services;

namespace SmartTripApp.Controllers
{
    public class TourController : Controller
    {
        private readonly TourRepository _tourRepository;
        private readonly DestinationRepository _destinationRepository;

        public TourController(TourRepository tourRepository, DestinationRepository destinationRepository)
        {
            _tourRepository = tourRepository;
            _destinationRepository = destinationRepository;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Tour> tours = await _tourRepository.GetAllWithDestinationsAsync();
            return View(tours);
        }


        [Authorize]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Destination> destinations = await _destinationRepository.GetAllAsync();
            ViewData["DestinationId"] = new SelectList(destinations, "Id", "Name");
            return View();
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tour tour)
        {
            ModelState.Remove("Destination");
            ModelState.Remove("Bookings");
            if (ModelState.IsValid)
            {
                await _tourRepository.AddAsync(tour);
                await _tourRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinationId"] = new SelectList(await _destinationRepository.GetAllAsync(), "Id", "Name", tour.DestinationId);
            return View(tour);
        }


        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _tourRepository.GetByIdAsync(id.Value);
            if (tour == null)
            {
                return NotFound();
            }
            ViewData["DestinationId"] = new SelectList(await _destinationRepository.GetAllAsync(), "Id", "Name", tour.DestinationId);
            return View(tour);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DestinationId,Name,StartDate,EndDate,Price,MaxSeats,BookedSeats")] Tour tour)
        {
            if (id != tour.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Destination");
            ModelState.Remove("Bookings");
            if (ModelState.IsValid)
            {
                try
                {
                    await _tourRepository.UpdateAsync(tour);
                    await _tourRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinationId"] = new SelectList(await _destinationRepository.GetAllAsync(), "Id", "Name", tour.DestinationId);
            return View(tour);
        }


        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var tour = await _tourRepository.GetByIdWithDestinationAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }


        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tour = await _tourRepository.GetByIdAsync(id);
            if (tour != null)
            {
                await _tourRepository.DeleteAsync(id);
                await _tourRepository.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tour? tour = await _tourRepository.GetByIdWithDestinationAsync(id.Value);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        private bool TourExists(int id)
        {
            return _tourRepository.GetByIdAsync(id).Result != null;
        }
    }
}

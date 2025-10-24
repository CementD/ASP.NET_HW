using Microsoft.AspNetCore.Mvc;
using SmartTripApp.Models;
using SmartTripApp.Repositories;
using SmartTripApp.Services;

namespace SmartTrip.Controllers
{
    public class BookingSearchController : Controller
    {
        private readonly DestinationRepository _destinationRepository;
        private readonly TourRepository _tourRepository;
        private readonly BookingRepository _bookingRepository;
        private readonly ITourService _tourService;
        private readonly IEmailService _emailService;

        public BookingSearchController(DestinationRepository destinationRepository, TourRepository tourRepository,
                                       BookingRepository bookingRepository, ITourService tourService, IEmailService emailService)
        {
            _destinationRepository = destinationRepository;
            _tourRepository = tourRepository;
            _bookingRepository = bookingRepository;
            _tourService = tourService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(TourSearch? tourSearch)
        {
            ViewBag.TourSearch = tourSearch;

            IEnumerable<Tour> tours = await _tourRepository.GetAllWithDestinationsAsync();

            if (tourSearch?.Country != null)
            {
                tours = tours.Where(t => t.Destination.Country == tourSearch.Country);
            }
            if (tourSearch?.MinPrice != null)
            {
                tours = tours.Where(t => t.Price >= tourSearch.MinPrice);
            }
            if (tourSearch?.MaxPrice != null)
            {
                tours = tours.Where(t => t.Price <= tourSearch.MaxPrice);
            }


            tours = tourSearch?.SortBy switch
            {
                TourSearch.TourSortOption.PriceAsc => tours.OrderBy(t => t.Price),
                TourSearch.TourSortOption.PriceDesc => tours.OrderByDescending(t => t.Price),
                TourSearch.TourSortOption.DateAsc => tours.OrderBy(t => t.StartDate),
                TourSearch.TourSortOption.DateDesc => tours.OrderByDescending(t => t.StartDate),
                TourSearch.TourSortOption.NameAsc => tours.OrderBy(t => t.Name),
                TourSearch.TourSortOption.NameDesc => tours.OrderByDescending(t => t.Name),
                _ => tours
            };
            return View(tours);
        }

        [HttpGet]
        public async Task<IActionResult> TourDetails(int id)
        {
            Tour? tour = await _tourRepository.GetByIdWithDestinationAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

        [HttpGet]
        public async Task<IActionResult> BookingForm(int tourId)
        {
            Tour? tour = await _tourRepository.GetByIdWithDestinationAsync(tourId);
            if (tour == null)
            {
                return NotFound();
            }
            ViewBag.Tour = tour;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookingForm(Booking booking)
        {
            var tour = await _tourRepository.GetByIdWithDestinationAsync(booking.TourId);
            if (tour == null)
                return NotFound();

            ModelState.Remove("Tour");
            ModelState.Remove("CreatedAt");
            if (!ModelState.IsValid)
            {
                ViewBag.Tour = tour;
                return View(booking);
            }

            if (!await _tourService.BookSeatsAsync(tour.Id, booking.Seats))
            {
                ModelState.AddModelError("", "This tour is no longer available for booking.");
                ViewBag.Tour = tour;
                return View(booking);
            }

            booking.CreatedAt = DateTime.Now;
            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();

            await _emailService.SendBookingConfirmationAsync(booking.Email, tour.Name, booking.Seats);

            TempData["Success"] = "Booking successful! Confirmation sent to your email.";
            return RedirectToAction(nameof(BookingConfirmation));
        }


        [HttpGet]
        public IActionResult BookingConfirmation()
        {
            return View();
        }

    }
}

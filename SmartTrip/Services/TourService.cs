using SmartTrip.Models;
using SmartTrip.Services.Interfaces;

namespace SmartTrip.Services
{
    public class TourService : ITourService
    {
        private static readonly List<Tour> _tours = new();
        private static readonly List<Booking> _bookings = new();

        public Task<IEnumerable<Tour>> GetAllAsync() =>
            Task.FromResult(_tours.AsEnumerable());

        public Task<Tour?> GetByIdAsync(int id) =>
            Task.FromResult(_tours.FirstOrDefault(t => t.Id == id));

        public Task AddAsync(Tour tour)
        {
            tour.Id = _tours.Count + 1;
            _tours.Add(tour);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Tour tour)
        {
            var existing = _tours.FirstOrDefault(t => t.Id == tour.Id);
            if (existing != null)
            {
                existing.Name = tour.Name;
                existing.Price = tour.Price;
                existing.StartDate = tour.StartDate;
                existing.EndDate = tour.EndDate;
                existing.MaxSeats = tour.MaxSeats;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var tour = _tours.FirstOrDefault(t => t.Id == id);
            if (tour != null) _tours.Remove(tour);
            return Task.CompletedTask;
        }

        public Task<bool> BookAsync(Booking booking)
        {
            var tour = _tours.FirstOrDefault(t => t.Id == booking.TourId);
            if (tour == null) return Task.FromResult(false);

            if (tour.BookedSeats + booking.Seats > tour.MaxSeats) return Task.FromResult(false);
            if (_bookings.Any(b => b.Email == booking.Email && b.TourId == booking.TourId)) return Task.FromResult(false);

            tour.BookedSeats += booking.Seats;
            booking.Id = _bookings.Count + 1;
            _bookings.Add(booking);
            return Task.FromResult(true);
        }
    }
}

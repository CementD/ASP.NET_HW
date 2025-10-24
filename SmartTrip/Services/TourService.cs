using Microsoft.EntityFrameworkCore;
using SmartTrip.Data;
using SmartTrip.Models;
using SmartTrip.Services.Interfaces;

namespace SmartTrip.Services
{
    public class TourService : ITourService
    {
        private readonly AppDbContext _context;

        public TourService(AppDbContext context)
        {
            _context = context;
        }

        // Логика бронирования тура
        public async Task<bool> BookTourAsync(int tourId, Booking booking)
        {
            var tour = await _context.Tours.FindAsync(tourId);
            if (tour == null) return false;

            // Проверяем доступные места
            if (tour.BookedSeats + booking.Seats > tour.MaxSeats)
                return false;

            // Проверяем уникальность email для тура
            bool exists = await _context.Bookings
                .AnyAsync(b => b.Email == booking.Email && b.TourId == tourId);
            if (exists) return false;

            // Добавляем бронь
            booking.TourId = tourId;
            tour.BookedSeats += booking.Seats;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetTotalBookingsAsync(int destinationId)
        {
            return await _context.Bookings
                .Include(b => b.Tour)
                .CountAsync(b => b.Tour!.DestinationId == destinationId);
        }

        public async Task<IEnumerable<Destination>> GetTopDestinationsAsync(int topCount)
        {
            var destinations = await _context.Destinations
                .Include(d => d.Tours!)
                    .ThenInclude(t => t.Bookings)
                .ToListAsync();

            return destinations
                .OrderByDescending(d => d.Tours!.Sum(t => t.Bookings!.Count))
                .Take(topCount)
                .ToList();
        }
    }
}

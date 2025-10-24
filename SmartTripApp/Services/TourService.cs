using Microsoft.EntityFrameworkCore;
using SmartTripApp.Data;
using SmartTripApp.Models;
using SmartTripApp.Repositories;

namespace SmartTripApp.Services
{
    public class TourService : ITourService
    {
        private readonly TourRepository _tourRepository;

        public TourService(TourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<bool> BookSeatsAsync(int tourId, int seatsToBook)
        {
            var tour = await _tourRepository.GetByIdAsync(tourId);
            if (tour == null) return false;

            if (tour.BookedSeats + seatsToBook > tour.MaxSeats ||
                tour.StartDate < DateOnly.FromDateTime(DateTime.Today))
                return false;

            tour.BookedSeats += seatsToBook;

            await _tourRepository.UpdateAsync(tour);
            await _tourRepository.SaveChangesAsync();
            return true;
        }
    }
}

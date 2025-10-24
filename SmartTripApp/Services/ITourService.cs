using SmartTripApp.Models;

namespace SmartTripApp.Services
{
    public interface ITourService
    {
        Task<bool> BookSeatsAsync(int tourId, int seatsToBook);
    }
}

using SmartTrip.Models;

namespace SmartTrip.Services.Interfaces
{
    public interface ITourService
    {
        Task<bool> BookTourAsync(int tourId, Booking booking);
        Task<int> GetTotalBookingsAsync(int destinationId);
        Task<IEnumerable<Destination>> GetTopDestinationsAsync(int topCount);
    }
}

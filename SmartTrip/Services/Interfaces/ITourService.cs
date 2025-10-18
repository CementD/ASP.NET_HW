using SmartTrip.Models;

namespace SmartTrip.Services.Interfaces
{
    public interface ITourService
    {
        Task<IEnumerable<Tour>> GetAllAsync();
        Task<Tour?> GetByIdAsync(int id);
        Task AddAsync(Tour tour);
        Task UpdateAsync(Tour tour);
        Task DeleteAsync(int id);
        Task<bool> BookAsync(Booking booking);
    }
}

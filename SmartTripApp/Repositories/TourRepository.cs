using Microsoft.EntityFrameworkCore;
using SmartTripApp.Data;
using SmartTripApp.Models;

namespace SmartTripApp.Repositories
{
    public class TourRepository : Repository<Tour>
    {
        public TourRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Models.Tour>> GetAllWithDestinationsAsync()
        {
            return await _context.Tours.Include(t => t.Destination).ToListAsync();
        }

        public async Task<Models.Tour?> GetByIdWithDestinationAsync(int id)
        {
            return await _context.Tours.Include(t => t.Destination).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SmartTripApp.Data;
using SmartTripApp.Models;

namespace SmartTripApp.Repositories
{
    public class DestinationRepository : Repository<Destination>
    {
        public DestinationRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Models.Destination?> GetByIdWithToursAsync(int id)
        {
            return await _context.Destinations.Include(d => d.Tours).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Models.Destination>> GetAllWithToursAsync()
        {
            return await _context.Destinations.Include(d => d.Tours).ToListAsync();
        }
    }
}

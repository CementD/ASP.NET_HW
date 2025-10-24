using Microsoft.EntityFrameworkCore;
using SmartTripApp.Data;
using SmartTripApp.Models;

namespace SmartTripApp.Repositories
{
    public class BookingRepository : Repository<Booking>
    {
        public BookingRepository(AppDbContext context) : base(context)
        {
        }
    }

}

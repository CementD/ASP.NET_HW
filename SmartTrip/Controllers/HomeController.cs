using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTrip.Data;

namespace SmartTrip.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _context.Tours
                .Include(t => t.Destination)
                .OrderBy(t => t.StartDate)
                .ToListAsync();

            return View(tours);
        }
    }
}

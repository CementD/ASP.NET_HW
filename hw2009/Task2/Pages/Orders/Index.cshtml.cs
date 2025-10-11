using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Models;

namespace Task2.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Order> Orders { get; set; } = new List<Order>();

        [BindProperty(SupportsGet = true)]
        public string? StatusFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? DateFilter { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .AsQueryable();

            if (!string.IsNullOrEmpty(StatusFilter) &&
                Enum.TryParse<OrderStatus>(StatusFilter, out var parsedStatus))
            {
                query = query.Where(o => o.Status == parsedStatus);
            }

            if (DateFilter.HasValue)
            {
                query = query.Where(o => o.OrderDate.Date == DateFilter.Value.Date);
            }

            Orders = await query.ToListAsync();
        }
    }
}

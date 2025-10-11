using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Models;

namespace Task2.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; } = new List<Customer>();

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.AsNoTracking().ToListAsync();
        }
    }
}

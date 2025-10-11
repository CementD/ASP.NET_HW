using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Models;

namespace Task2.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        public DetailsModel(AppDbContext context) => _context = context;

        public Customer? Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Customer == null)
                return NotFound();

            return Page();
        }
    }
}

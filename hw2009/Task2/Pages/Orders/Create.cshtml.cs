using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Models;

namespace Task2.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = new();

        public List<Customer> Customers { get; set; } = new();

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Customers = await _context.Customers.ToListAsync();
                return Page();
            }

            Order.OrderDate = DateTime.Now;
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

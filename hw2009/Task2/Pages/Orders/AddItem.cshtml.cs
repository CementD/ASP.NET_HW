using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Models;

namespace Task2.Pages.Orders
{
    public class AddItemModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddItemModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; } = new();

        public List<Product> Products { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int OrderId { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var product = await _context.Products.FindAsync(OrderItem.ProductId);
            var order = await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == OrderItem.OrderId);

            if (product == null || order == null)
                return NotFound();

            if (OrderItem.Quantity <= 0 || OrderItem.Quantity > product.StockQuantity)
            {
                ModelState.AddModelError(string.Empty, "Invalid quantity.");
                Products = await _context.Products.ToListAsync();
                return Page();
            }

            OrderItem.UnitPrice = product.Price;
            order.OrderItems.Add(OrderItem);

            // уменьшение склада
            product.StockQuantity -= OrderItem.Quantity;

            // пересчёт общей суммы
            order.Total = order.OrderItems.Sum(i => i.LineTotal);

            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new { id = OrderItem.OrderId });
        }
    }
}

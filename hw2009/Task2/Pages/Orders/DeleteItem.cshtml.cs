using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Models;

namespace Task2.Pages.Orders
{
    public class DeleteItemModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteItemModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int OrderId { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            OrderItem = await _context.OrderItems
                .Include(i => i.Product)
                .Include(i => i.Order)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (OrderItem == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var item = await _context.OrderItems
                .Include(i => i.Product)
                .Include(i => i.Order)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
                return NotFound();

            // вернуть товар на склад
            item.Product!.StockQuantity += item.Quantity;

            // удалить позицию и пересчитать сумму
            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();

            var order = await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == item.OrderId);
            if (order != null)
            {
                order.Total = order.OrderItems.Sum(i => i.LineTotal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Details", new { id = item.OrderId });
        }
    }
}

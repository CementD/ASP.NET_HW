using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task3.Data;
using Task3.Models;

namespace Task3.Pages.Dishes
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Dish> Dishes { get; set; } = new();
        public List<Category> Categories { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();

            var query = _context.Dishes
                .Include(d => d.DishCategories)
                    .ThenInclude(dc => dc.Category)
                .Include(d => d.Restaurant)
                .AsQueryable();

            if (CategoryId.HasValue)
            {
                query = query.Where(d => d.DishCategories.Any(dc => dc.CategoryId == CategoryId.Value));
            }

            Dishes = await query.ToListAsync();
        }
    }
}
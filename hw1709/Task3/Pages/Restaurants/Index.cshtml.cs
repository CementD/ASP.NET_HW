using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task3.Data;
using Task3.Models;

namespace Task3.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public List<Restaurant> Restaurants { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Restaurants
                .Include(r => r.Dishes)
                    .ThenInclude(d => d.DishCategories)
                    .ThenInclude(dc => dc.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(SearchName))
            {
                query = query.Where(r => r.Name.Contains(SearchName));
            }

            Restaurants = await query.ToListAsync();
            foreach (var r in Restaurants)
            {
                r.Dishes = SortOrder == "price_desc"
                    ? r.Dishes.OrderByDescending(d => d.Price).ToList()
                    : r.Dishes.OrderBy(d => d.Price).ToList();
            }

            int pageSize = 5;
            TotalPages = (int)Math.Ceiling(Restaurants.Count / (double)pageSize);
            Restaurants = Restaurants
                .Skip((PageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}

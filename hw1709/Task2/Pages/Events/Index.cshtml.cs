using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Models;

namespace Task2.Pages.Events
{
    public class IndexModel : PageModel
    {
        public readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Event> Events { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public async Task OnGetAsync()
        {
            var query = _context.Events
                .Include(e => e.EventParticipants)
                .ThenInclude(ep => ep.Participant)
                .AsQueryable();
            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(e => e.Title.Contains(SearchString) || e.Location.Contains(SearchString));
            }

            query = SortOrder == "count_desc"
                ? query.OrderByDescending(e => e.EventParticipants.Count)
                : query.OrderBy(e => e.EventParticipants.Count);

            const int pageSize = 10;
            int totalEvents = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalEvents / (double)pageSize);

            Events = await query
                .Skip((PageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}

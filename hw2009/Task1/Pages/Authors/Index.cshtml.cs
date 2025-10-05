using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1.Data;
using Task1.Models;

namespace Task1.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public IList<Author> Authors { get; set; }
        public async Task OnGetAsync()
        {
            Authors = await _context.Authors
                .Include(a => a.Books)
                .ToListAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1.Data;
using Task1.Models;

namespace Task1.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public IList<Book> Books { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Books = await _context.Books
                    .Include(b => b.Author)
                    .ToListAsync();
            }
        }

    }
}

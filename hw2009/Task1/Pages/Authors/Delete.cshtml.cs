using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1.Data;
using Task1.Models;

namespace Task1.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;
        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Author Author { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Author = await _context.Authors.FindAsync(id);
            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Author = await _context.Authors.FindAsync(id);
            if (Author != null)
            {
                _context.Authors.Remove(Author);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}

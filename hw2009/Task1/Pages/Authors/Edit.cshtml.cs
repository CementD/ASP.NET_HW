using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1.Data;
using Task1.Models;

namespace Task1.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;
        public EditModel(AppDbContext context)
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Update(Author);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

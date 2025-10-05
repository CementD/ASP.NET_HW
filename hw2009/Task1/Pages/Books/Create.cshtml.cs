using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1.Data;
using Task1.Models;

namespace Task1.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        public CreateModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }
        public List<Author> AuthorList { get; set; }
        public void OnGet()
        {
            AuthorList = _context.Authors.ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

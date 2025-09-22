using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hw1509.Data;
using hw1509.Models;

namespace hw1509.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = new Student();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await _context.Students.FindAsync(id);

            if (Student == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Students.Any(e => e.Id == Student.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("Index");
        }
    }
}

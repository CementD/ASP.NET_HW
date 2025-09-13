using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ModalWork1309.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        [Required, StringLength(50)]
        public string Name { get; set; }
        [BindProperty]
        [Required, EmailAddress]
        public string Email { get; set; }
        [BindProperty]
        [StringLength(200)]
        public string Bio { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TempData["Message"] = "Profile saved successfully!";
            return Page();
        }
    }
}

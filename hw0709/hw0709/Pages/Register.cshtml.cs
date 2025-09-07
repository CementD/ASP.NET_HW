using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace hw0709.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Name is required!"), StringLength(50)]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Email is required!"), EmailAddress(ErrorMessage = "Incorrect email format!")]
        public string Email { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Password is required!"), DataType(DataType.Password), StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Confirm password!"), DataType(DataType.Password), Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Age is required!"), Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["SuccessMessage"] = "Registration successful!";
            return RedirectToPage("SuccessRegistration");
        }
    }
}

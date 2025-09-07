using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace hw0709.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Full Name is required!"), StringLength(100)]
        public string FullName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Email is required!"), EmailAddress(ErrorMessage = "Incorrect email format!")]
        public string Email { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Message is required!"), StringLength(1000, ErrorMessage = "Message cannot exceed 500 characters.", MinimumLength = 10)]
        public string Message { get; set; }
        public static List<(string FullName, string Email, string Message)> Messages = new();
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Messages.Add((FullName, Email, Message));
            return RedirectToPage("ThankYou");
        }
    }
}

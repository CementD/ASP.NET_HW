using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace hw0709.Pages
{
    public class NewsletterModel : PageModel
    {
        [BindProperty]
        [EmailAddress(ErrorMessage = "Incorrect email format!")]
        public string Email { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["SuccessMessage"] = "Subscription successful!";
            return RedirectToPage("SuccessSubscription");
        }
    }
}

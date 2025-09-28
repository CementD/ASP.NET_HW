using hw2709.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2709.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(ContactForm contactForm)
        {
            if (!ModelState.IsValid)
            {
                return View(contactForm);
            }
            return Content($"Message sent: {contactForm.Message}");
        }
    }
}

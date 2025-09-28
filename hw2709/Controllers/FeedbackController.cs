using hw2709.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2709.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feedback feedback)
        {
            if (feedback.Message != null && feedback.Message.Contains("bad"))
            {
                ModelState.AddModelError("Message", "Inappropriate content should be deleted.");
            }
            if (!ModelState.IsValid)
            {
                return View(feedback);
            }
            return Content($"Feedback received: {feedback.Message}");
        }
    }
}

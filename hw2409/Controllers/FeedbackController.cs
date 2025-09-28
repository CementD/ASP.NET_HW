using hw2409.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2409.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                return View("Result", feedback);
            }
            return View(feedback);
        }
    }
}

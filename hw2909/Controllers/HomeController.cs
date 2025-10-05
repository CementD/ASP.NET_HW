using System.Diagnostics;
using hw2909.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2909.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            string url = Url.RouteUrl("catalog", new { category = "books", page = 1, sort = "name" });
            string html = $"<a href='{url}'>Go to category 'books'</a>";
            return Content(html, "text/html");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

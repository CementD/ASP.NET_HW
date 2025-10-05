using System.Diagnostics;
using hw0110.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw0110.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to home page";
            ViewBag.Number = 52;
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}

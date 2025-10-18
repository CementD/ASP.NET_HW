using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmartTrip.Models;

namespace SmartTrip.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

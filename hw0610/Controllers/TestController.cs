using hw0610.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Cotroll_Group.Controllers
{
    public class TestController : Controller
    {
        private readonly IRandomNumberService _randomService;

        public TestController(IRandomNumberService randomService)
        {
            _randomService = randomService;
        }

        public IActionResult Index()
        {
            ViewBag.Random = _randomService.GetRandomNumber();
            return View();
        }
    }
}

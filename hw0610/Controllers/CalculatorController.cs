using hw0610.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Cotroll_Group.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(int a, int b, string operation)
        {
            string result = operation switch
            {
                "add" => $"Result: {_calculatorService.Add(a, b)}",
                "divide" => $"Result: {_calculatorService.Divide(a, b)}",
                _ => "Unknown operation"
            };

            ViewBag.Result = result;
            return View();
        }
    }
}

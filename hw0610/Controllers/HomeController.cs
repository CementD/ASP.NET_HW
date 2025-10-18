using hw0610.Services;
using Microsoft.AspNetCore.Mvc;

namespace hw0610.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IDateTimeService _dateTimeService;
        private readonly IRandomNumberService _randomService;

        public HomeController(IMessageService messageService, IDateTimeService dateTimeService, IRandomNumberService randomService)
        {
            _messageService = messageService;
            _dateTimeService = dateTimeService;
            _randomService = randomService;
        }

        public IActionResult Index()
        {
            ViewBag.Message = _messageService.GetMessage();
            ViewBag.Date = _dateTimeService.GetCurrentDateTime();
            ViewBag.Random = _randomService.GetRandomNumber();
            return View();
        }
    }
}

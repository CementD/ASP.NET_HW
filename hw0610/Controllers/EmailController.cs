using hw0610.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Cotroll_Group.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string to)
        {
            ViewBag.Message = _emailService.SendEmail(to);
            return View();
        }
    }
}

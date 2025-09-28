using hw2409.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2409.Controllers
{
    public class TicketController : Controller
    {
        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Order(TicketOrder ticketOrder)
        {
            if (ModelState.IsValid)
            {
                return View("Confirmation", ticketOrder);
            }
            return View(ticketOrder);
        }
    }
}

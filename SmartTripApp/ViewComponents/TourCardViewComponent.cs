using Microsoft.AspNetCore.Mvc;
using SmartTripApp.Models;

namespace SmartTripApp.ViewComponents
{
    public class TourCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Tour tour)
        {
            return View("TourCard", tour);
        }
    }
}

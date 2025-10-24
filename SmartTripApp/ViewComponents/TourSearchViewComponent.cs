using Microsoft.AspNetCore.Mvc;
using SmartTripApp.Models;

namespace SmartTripApp.ViewComponents
{
    public class TourSearchViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(TourSearch? tourSearch)
        {
            var model = tourSearch ?? new TourSearch();
            return View(model);
        }
    }
}

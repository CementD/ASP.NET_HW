using hw0810.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hw0810.ViewComponents
{
    public class NotificationsViewComponent : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public NotificationsViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int userId)
        {
            var items = await _notificationService.GetUnreadForUserAsync(userId);
            return View(items);
        }
    }
}

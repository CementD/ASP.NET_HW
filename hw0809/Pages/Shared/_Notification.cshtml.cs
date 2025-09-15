using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hw0809.Pages.Shared
{
    public class _NotificationModel : PageModel
    {
        public void OnGet()
        {
            TempData["Messages"] = new List<(string, string)>
            {
                ("success", "Successfuly loged in"),
                ("danger", "Eroor occured")
            };
        }
    }
}

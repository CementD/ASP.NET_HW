using hw0810.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hw0810.ViewComponents
{
    public class LatestPostsViewComponent : ViewComponent
    {
        private readonly IPostService _postService;

        public LatestPostsViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool compact = false)
        {
            var posts = await _postService.GetLatestAsync(5);
            var viewName = compact ? "Compact" : "Default";
            return View(viewName, posts);
        }
    }
}

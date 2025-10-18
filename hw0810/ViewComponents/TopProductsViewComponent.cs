using hw0810.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hw0810.ViewComponents
{
    public class TopProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public TopProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count = 3)
        {
            var top = await _productService.GetTopByPriceAsync(count);
            return View("Default", top);
        }
    }
}

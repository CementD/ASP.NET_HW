using hw0810.Models;
using hw0810.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hw0810.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IPostService _postService;

        public HomeController(IProductService productService, IPostService postService)
        {
            _productService = productService;
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            ViewBag.TopProducts = await _productService.GetTopByPriceAsync(3);
            return View(products);
        }
    }
}

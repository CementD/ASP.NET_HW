using hw0810.Models;
using hw0810.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hw0810.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _svc;
        public ProductsController(IProductService svc) => _svc = svc;

        public async Task<IActionResult> Index()
        {
            var list = await _svc.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var p = await _svc.GetByIdAsync(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model, int? returnCategory)
        {
            if (!ModelState.IsValid) return View(model);
            await _svc.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}

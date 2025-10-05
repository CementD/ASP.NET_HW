using Microsoft.AspNetCore.Mvc;

namespace hw2909.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Search(string? name, int? categoryId)
        {
            return Content($"Name = {name}, CategoryId = {categoryId}");
        }

        public IActionResult Category(string category, int? page, string? sort)
        {
            return Content($"Category = {category}, Page = {page}, Sort = {sort}");
        }
    }
}

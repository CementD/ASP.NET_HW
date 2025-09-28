using hw2209.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2209.Controllers
{
    public class TodoController : Controller
    {
        private static List<ToDoItem> toDos = new List<ToDoItem>
        {
            new ToDoItem { Id = 1, Title = "Buy groceries", IsCompleted = false },
            new ToDoItem { Id = 2, Title = "Walk the dog", IsCompleted = true },
            new ToDoItem { Id = 3, Title = "Finish homework", IsCompleted = false }
        };
        public IActionResult Index()
        {
            return View(toDos);
        }

        [HttpPost]
        public IActionResult Add(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                var newItem = new ToDoItem
                {
                    Id = toDos.Count > 0 ? toDos.Max(t => t.Id) + 1 : 1,
                    Title = title,
                    IsCompleted = false
                };
                toDos.Add(newItem);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ToggleComplete(int id)
        {
            var item = toDos.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
            }
            return RedirectToAction("Index");
        }
    }
}

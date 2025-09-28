using hw2209.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw2209.Controllers
{
    public class PostsController : Controller
    {
        private static List<Post> posts = new List<Post>
        {
            new Post { Title = "First Post", Content = "This is the content of the first post.", Author = "Alice" },
            new Post { Title = "Second Post", Content = "This is the content of the second post.", Author = "Bob" }
        };

        public IActionResult Index()
        {
            return View(posts);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                posts.Add(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }
        public IActionResult Details(int id)
        {
            if (id < 0 || id >= posts.Count)
            {
                return NotFound();
            }
            var post = posts[id];
            return View(post);
        }
    }
}

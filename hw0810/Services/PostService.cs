using hw0810.Models;
using hw0810.Services.Interfaces;

namespace hw0810.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts = new()
        {
            new Post{ Id=1, Title="Welcome to the shop", CreatedAt=DateTime.UtcNow.AddDays(-1) },
            new Post{ Id=2, Title="Black Friday Deals", CreatedAt=DateTime.UtcNow.AddDays(-5) },
            new Post{ Id=3, Title="How to choose a camera", CreatedAt=DateTime.UtcNow.AddDays(-2) },
            new Post{ Id=4, Title="Laptop buying guide", CreatedAt=DateTime.UtcNow.AddHours(-3) },
            new Post{ Id=5, Title="Top headphones 2025", CreatedAt=DateTime.UtcNow.AddDays(-10) },
            new Post{ Id=6, Title="Summer accessories", CreatedAt=DateTime.UtcNow.AddDays(-20) }
        };

        public Task AddAsync(Post p)
        {
            p.Id = _posts.Any() ? _posts.Max(x => x.Id) + 1 : 1;
            _posts.Add(p);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Post>> GetLatestAsync(int count)
            => Task.FromResult<IEnumerable<Post>>(_posts.OrderByDescending(p => p.CreatedAt).Take(count).ToList());
    }
}

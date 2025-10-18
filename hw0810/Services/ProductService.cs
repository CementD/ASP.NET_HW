using hw0810.Models;
using hw0810.Services.Interfaces;

namespace hw0810.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _store = new()
        {
            new Product{ Id=1, Name="Phone", Price=799.99m, Description="Smartphone", ImageUrl="https://via.placeholder.com/300" },
            new Product{ Id=2, Name="Laptop", Price=1299.50m, Description="Powerful laptop", ImageUrl="https://via.placeholder.com/300" },
            new Product{ Id=3, Name="Headphones", Price=199.00m, Description="Noise cancelling", ImageUrl="https://via.placeholder.com/300" },
            new Product{ Id=4, Name="Camera", Price=899.00m, Description="Mirrorless camera", ImageUrl="https://via.placeholder.com/300" }
        };

        public Task AddAsync(Product p)
        {
            p.Id = _store.Any() ? _store.Max(x => x.Id) + 1 : 1;
            _store.Add(p);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
            => Task.FromResult<IEnumerable<Product>>(_store.OrderBy(p => p.Name).ToList());

        public Task<Product?> GetByIdAsync(int id)
            => Task.FromResult(_store.FirstOrDefault(p => p.Id == id));

        public Task<IEnumerable<Product>> GetTopByPriceAsync(int count)
            => Task.FromResult<IEnumerable<Product>>(_store.OrderByDescending(p => p.Price).Take(count).ToList());
    }
}

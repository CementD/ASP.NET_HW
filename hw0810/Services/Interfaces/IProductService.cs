using hw0810.Models;

namespace hw0810.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetTopByPriceAsync(int count);
        Task AddAsync(Product p);
    }
}

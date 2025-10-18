using hw0810.Models;

namespace hw0810.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetLatestAsync(int count);
        Task AddAsync(Post p);
    }
}

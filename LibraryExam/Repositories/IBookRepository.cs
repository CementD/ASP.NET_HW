using LibraryExam.Models;

namespace LibraryExam.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book?> GetByIsbnAsync(string isbn);
        Task<IEnumerable<Book>> SearchAsync(string? title, string? author, string? isbn);
    }
}

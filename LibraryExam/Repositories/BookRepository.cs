using LibraryExam.Data;
using LibraryExam.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryExam.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<Book?> GetByIsbnAsync(string isbn)
        {
            return await _ctx.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
        }

        public async Task<IEnumerable<Book>> SearchAsync(string? title, string? author, string? isbn)
        {
            var q = _ctx.Books.AsQueryable();
            if (!string.IsNullOrWhiteSpace(title)) q = q.Where(b => b.Title.Contains(title));
            if (!string.IsNullOrWhiteSpace(author)) q = q.Where(b => b.Author.Contains(author));
            if (!string.IsNullOrWhiteSpace(isbn)) q = q.Where(b => b.ISBN.Contains(isbn));
            return await q.ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace hw2210.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Book> Books { get; set; }
    }
}

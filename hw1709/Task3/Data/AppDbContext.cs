using Microsoft.EntityFrameworkCore;
using Task3.Models;

namespace Task3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishCategory>()
                .HasKey(dc => new { dc.DishId, dc.CategoryId });
            modelBuilder.Entity<DishCategory>()
                .HasOne(dc => dc.Dish)
                .WithMany(d => d.DishCategories)
                .HasForeignKey(dc => dc.DishId);
            modelBuilder.Entity<DishCategory>()
                .HasOne(dc => dc.Category)
                .WithMany(c => c.DishCategories)
                .HasForeignKey(dc => dc.CategoryId);
        }
    }
}

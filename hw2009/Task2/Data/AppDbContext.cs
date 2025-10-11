using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FullName = "Alice Example", Email = "alice@example.com", Phone = "1234567890" },
                new Customer { Id = 2, FullName = "Bob Example", Email = "bob@example.com", Phone = "0987654321" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Apple", Price = 1.50m, StockQuantity = 100 },
                new Product { Id = 2, Name = "Banana", Price = 2.00m, StockQuantity = 50 },
                new Product { Id = 3, Name = "Milk", Price = 3.00m, StockQuantity = 30 }
            );
        }
    }
}

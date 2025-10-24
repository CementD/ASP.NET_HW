using Microsoft.EntityFrameworkCore;
using SmartTrip.Models;

namespace SmartTrip.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Таблицы (DbSet)
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Destination> Destinations { get; set; } = default!;
        public DbSet<Tour> Tours { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Связь: Destination → Tours (один-ко-многим)
            modelBuilder.Entity<Tour>()
                .HasOne(t => t.Destination)
                .WithMany(d => d.Tours)
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь: Tour → Bookings (один-ко-многим)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Tour)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TourId)
                .OnDelete(DeleteBehavior.Cascade);

            // Уникальный Email для каждого тура (Booking)
            modelBuilder.Entity<Booking>()
                .HasIndex(b => new { b.Email, b.TourId })
                .IsUnique();

            // Первичная инициализация данных (пример)
            modelBuilder.Entity<Destination>().HasData(
                new Destination
                {
                    Id = 1,
                    Name = "Paris",
                    Country = "France",
                    Description = "City of Light and romance.",
                    ImageUrl = "https://example.com/paris.jpg"
                },
                new Destination
                {
                    Id = 2,
                    Name = "Rome",
                    Country = "Italy",
                    Description = "Historic city with rich culture.",
                    ImageUrl = "https://example.com/rome.jpg"
                }
            );

            modelBuilder.Entity<Tour>().HasData(
                new Tour
                {
                    Id = 1,
                    DestinationId = 1,
                    Name = "Paris Weekend Getaway",
                    StartDate = DateTime.UtcNow.AddDays(10),
                    EndDate = DateTime.UtcNow.AddDays(13),
                    Price = 499.99m,
                    MaxSeats = 20,
                    BookedSeats = 0
                },
                new Tour
                {
                    Id = 2,
                    DestinationId = 2,
                    Name = "Explore Rome 5 Days",
                    StartDate = DateTime.UtcNow.AddDays(20),
                    EndDate = DateTime.UtcNow.AddDays(25),
                    Price = 699.99m,
                    MaxSeats = 15,
                    BookedSeats = 0
                }
            );

            // Админ по умолчанию
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "admin@smarttrip.com",
                    Password = "admin123", // ⚠️ для тестов, не для продакшена
                    Role = Role.Admin
                }
            );
        }
    }
}
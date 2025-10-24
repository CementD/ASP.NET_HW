using Microsoft.EntityFrameworkCore;
using SmartTripApp.Models;

namespace SmartTripApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<AppAdmin> Admins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Destination>()
                .Property(d => d.Country)
                .HasConversion<string>();

            modelBuilder.Entity<Tour>()
                .HasOne(t => t.Destination)
                .WithMany(d => d.Tours)
                .HasForeignKey(t => t.DestinationId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Tour)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TourId);
        }
    }
}

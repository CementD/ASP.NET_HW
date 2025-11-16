using LibraryExam.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryExam.Data
{
    public class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext ctx)
        {
            await ctx.Database.MigrateAsync();

            if (!await ctx.Users.AnyAsync())
            {
                ctx.Users.AddRange(
                    new User { FirstName = "Admin", LastName = "User", Email = "admin@local", PasswordHash = "admin123", Role = "Admin" },
                    new User { FirstName = "John", LastName = "Doe", Email = "john@local", PasswordHash = "password", Role = "User" }
                );
            }

            if (!await ctx.Books.AnyAsync())
            {
                ctx.Books.AddRange(
                    new Book { Title = "Clean Code", Author = "Robert C. Martin", ISBN = "9780132350884", CopiesAvailable = 3 },
                    new Book { Title = "The Pragmatic Programmer", Author = "Andrew Hunt", ISBN = "9780201616224", CopiesAvailable = 2 }
                );
            }

            await ctx.SaveChangesAsync();
        }
    }
}

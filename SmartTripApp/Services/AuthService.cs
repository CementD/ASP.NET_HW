using Microsoft.EntityFrameworkCore;
using SmartTripApp.Data;
using SmartTripApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace SmartTripApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppAdmin?> ValidateUserAsync(string username, string password)
        {
            var hash = HashPassword(password);
            return await _context.Admins
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == hash);
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}

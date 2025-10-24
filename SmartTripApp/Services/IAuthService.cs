using SmartTripApp.Models;

namespace SmartTripApp.Services
{
    public interface IAuthService
    {
        Task<AppAdmin?> ValidateUserAsync(string username, string password);
        string HashPassword(string password);
    }
}

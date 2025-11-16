using LibraryExam.Models;

namespace LibraryExam.Services
{
    public interface IJwtService
    {
        string CreateToken(User user);
        DateTime GetExpiration();
    }
}

using exam0211.Models;

namespace exam0211.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
    }
}

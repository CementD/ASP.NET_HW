using LibraryExam.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryExam.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _cfg;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _key;
        private readonly int _minutes;

        public JwtService(IConfiguration cfg)
        {
            _cfg = cfg;
            _issuer = _cfg["Jwt:Issuer"] ?? "library-api";
            _audience = _cfg["Jwt:Audience"] ?? "library-api";
            _key = _cfg["Jwt:Key"] ?? "very_secure_key_replace";
            _minutes = int.TryParse(_cfg["Jwt:ExpiresMinutes"], out var m) ? m : 60;
        }

        public DateTime GetExpiration()
        {
            return DateTime.UtcNow.AddMinutes(_minutes);
        }

        public string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("role", user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: GetExpiration(),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

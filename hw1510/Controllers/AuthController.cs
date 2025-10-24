using hw1510.DTO;
using Microsoft.AspNetCore.Mvc;

namespace YourApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // POST /api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            if (login.Username == "admin" && login.Password == "1234")
                return Ok(new { Message = "Login successful", User = login.Username });

            return Unauthorized(new { Message = "Invalid username or password" });
        }

        // POST /api/auth/logout
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new { Message = "User logged out successfully" });
        }
    }
}

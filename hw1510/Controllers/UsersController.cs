using Microsoft.AspNetCore.Mvc;

namespace YourApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // POST /api/users/{id}/activate
        [HttpPost("{id}/activate")]
        public IActionResult ActivateUser([FromRoute] int id)
        {
            return Ok(new { UserId = id, Activated = true, Message = "User activated successfully" });
        }

        // POST /api/users/{id}/reset-password
        [HttpPost("{id}/reset-password")]
        public IActionResult ResetPassword([FromRoute] int id)
        {
            return Ok(new { UserId = id, Message = "Password reset successfully" });
        }

        // GET /api/users/search?term=...
        [HttpGet("search")]
        public IActionResult SearchUsers([FromQuery] string term)
        {
            var results = new[]
            {
                new { Id = 1, Name = "Alice" },
                new { Id = 2, Name = "Bob" },
                new { Id = 3, Name = "Charlie" }
            }.Where(u => u.Name.Contains(term, StringComparison.OrdinalIgnoreCase));

            return Ok(new { Term = term, Results = results });
        }
    }
}

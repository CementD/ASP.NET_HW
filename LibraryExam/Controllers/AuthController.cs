using AutoMapper;
using LibraryExam.DTOs;
using LibraryExam.Models;
using LibraryExam.Repositories;
using LibraryExam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwt;
        private readonly IMapper _mapper;

        public AuthController(IUserRepository userRepo, IJwtService jwt, IMapper mapper)
        {
            _userRepo = userRepo;
            _jwt = jwt;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _userRepo.ExistsAsync(u => u.Email == dto.Email))
                return Conflict(new { message = "Email already registered" });

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = dto.Password, // NOTE: in prod hash this
                Role = dto.Role ?? "User",
                MembershipDate = DateTime.UtcNow
            };

            await _userRepo.AddAsync(user);
            await _userRepo.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(user);
            return CreatedAtAction(nameof(GetProfile), new { id = user.Id }, userDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null) return Unauthorized();

            // simple password check (in prod use hash + salt)
            if (user.PasswordHash != dto.Password) return Unauthorized();

            var token = _jwt.CreateToken(user);
            var result = new AuthResultDto { Token = token, ExpiresAt = _jwt.GetExpiration(), Role = user.Role };

            return Ok(result);
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            // optional: get user from claims
            return Ok();
        }
    }
}

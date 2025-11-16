using AutoMapper;
using LibraryExam.DTOs;
using LibraryExam.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repo.GetAllAsync();
            return Ok(users.Select(u => _mapper.Map<UserDto>(u)));
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repo.GetAsync(id);
            if (user == null) return NotFound();
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost("{id:int}/activate")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Activate([FromRoute] int id)
        {
            var user = await _repo.GetAsync(id);
            if (user == null) return NotFound();
            user.Role = "User";
            await _repo.UpdateAsync(user);
            await _repo.SaveChangesAsync();
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost("{id:int}/reset-password")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ResetPassword([FromRoute] int id)
        {
            var user = await _repo.GetAsync(id);
            if (user == null) return NotFound();
            user.PasswordHash = "new-default-password";
            await _repo.UpdateAsync(user);
            await _repo.SaveChangesAsync();
            return Ok(new { message = "Password reset", userId = id });
        }

        [HttpGet("search")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var q = _repo.Query();
            if (!string.IsNullOrWhiteSpace(term))
            {
                q = q.Where(u => u.FirstName.Contains(term) || u.LastName.Contains(term) || u.Email.Contains(term));
            }
            var result = await q.ToListAsync();
            return Ok(result.Select(u => _mapper.Map<UserDto>(u)));
        }
    }
}

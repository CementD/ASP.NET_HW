using AutoMapper;
using level3.DTO;
using level3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace level3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        public UsersController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet("roles")]
        public IActionResult GetUsersWithRoles()
        {
            var users = new List<User>
            {
                new User { Name = "Admin", Roles = new List<Role> { new() { Name = "Admin" }, new() { Name = "Guest" } } },
                new User { Name = "Editor", Roles = new List<Role> { new() { Name = "Editor" } } }
            };

            var dtoList = _mapper.Map<List<UserDto>>(users);
            return Ok(dtoList);
        }
    }
}

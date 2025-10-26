using AutoMapper;
using level2.DTO;
using level2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace level2.Controllers
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
        [HttpGet("list")]
        public IActionResult GetUsers()
        {
            var users = new List<User>
            {
                new User { Name = "Alice", Age = 25, Address = new Address { City = "Kyiv", Street = "Main 1" } },
                new User { Name = "Bob", Age = 30, Address = new Address { City = "Lviv", Street = "Green 7" } }
            };

            var dtoList = _mapper.Map<List<UserDto>>(users);
            return Ok(dtoList);
        }
    }
}

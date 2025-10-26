using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace level1.Controllers
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

        [HttpGet("single")]
        public IActionResult GetUser()
        {
            var user = new User { Id = 1, Name = "Semen Domin", Email = "sem@gmail.com" };
            var dto = _mapper.Map<UserDto>(user);
            return Ok(dto);
        }
    }
}

using AutoMapper;
using level3.DTO;
using level3.Models;

namespace level3
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles
                .Where(r => r.Name != "Guest")
                .Select(r => r.Name)
                .ToList()));
        }
    }
}

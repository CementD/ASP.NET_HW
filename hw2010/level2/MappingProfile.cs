using AutoMapper;
using level2.Models;
using level2.DTO;

namespace level2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Address, AddressDto>();
        }
    }
}

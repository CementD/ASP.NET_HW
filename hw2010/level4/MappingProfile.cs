using AutoMapper;
using level4.DTO;
using level4.Models;

namespace level4
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.Items.Sum(i => i.Quantity)))
            .ForMember(dest => dest.ProductNames, opt => opt.MapFrom(src => src.Items.Select(i => i.ProductName).ToList()));
        }
    }
}

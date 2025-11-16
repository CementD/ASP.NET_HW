using AutoMapper;
using LibraryExam.DTOs;
using LibraryExam.Models;

namespace LibraryExam.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<Loan, LoanDto>().ReverseMap();
            CreateMap<LoanCreateDto, Loan>();
        }
    }
}

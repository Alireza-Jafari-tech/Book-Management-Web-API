using AutoMapper;
using apiApp.Models;
using apiApp.DTOs;

namespace apiApp.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();
        }
    }
}
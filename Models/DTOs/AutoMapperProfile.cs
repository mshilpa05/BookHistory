using AutoMapper;

namespace BookHistory.Models.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookViewDTO>();
            CreateMap<BookCreateDTO, Book>();
        }
    }
}

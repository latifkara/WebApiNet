using AutoMapper;
using WebApiNet.BookOperations.CreateBook;
using WebApiNet.BookOperations.GetBookDetail;
using WebApiNet.BookOperations.GetBooks;

namespace WebApiNet.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book,GetBookDetailModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=> ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=> ((GenreEnum)src.GenreId).ToString()));

             
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiNet.DbOperations;
using WebApiNet.Common;
using AutoMapper;

namespace WebApiNet.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly IMapper _mapper; 
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetBookDetailModel Handle()
        {
            var book = _dbContext.Books.Where(book=> book.Id == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap Bulunmadı");
             GetBookDetailModel vm = _mapper.Map<GetBookDetailModel>(book);
             return vm;
        }
        
    }

    public class GetBookDetailModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
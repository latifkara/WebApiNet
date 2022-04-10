using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiNet.DbOperations;
using WebApiNet.Common;

namespace WebApiNet.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GetBookDetailModel Handle()
        {
             var book = _dbContext.Books.Where(book=> book.Id == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap Bulunmadı");
             GetBookDetailModel vm = new GetBookDetailModel();
             vm.Title = book.Title;
             vm.Genre = ((GenreEnum)book.GenreId).ToString();
             vm.PageCount = book.PageCount;
             vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
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
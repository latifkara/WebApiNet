using WebApiNet.Common;
using WebApiNet.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiNet.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel up_Model { get; set;}
        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set;}
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public void Handle()
        {
             var book = _dbContext.Books.SingleOrDefault(x=> x.Id == BookId);

            if(book is null)
                 throw new InvalidOperationException("Güncellenecek Kitap Bulunmadı");

            book.Title = up_Model.Title != default ? up_Model.Title : book.Title;
            book.GenreId = up_Model.GenreId != default ? up_Model.GenreId : book.GenreId;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}
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
        private readonly int _id;
        public UpdateBookCommand(BookStoreDbContext dbContext,int id)
        {
            _dbContext = dbContext;
            _id = id;
        }

        public void Handle()
        {
             var book = _dbContext.Books.SingleOrDefault(x=> x.Id == _id);

            if(book is null)
                 throw new InvalidOperationException("Kitap yok");

            book.GenreId = up_Model.GenreId != default ? up_Model.GenreId : book.GenreId;
            book.PageCount = up_Model.PageCount != default ? up_Model.PageCount : book.PageCount;
            book.PublishDate = up_Model.PublishDate != default ? up_Model.PublishDate : book.PublishDate;
            book.Title = up_Model.Title != default ? up_Model.Title : book.Title;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
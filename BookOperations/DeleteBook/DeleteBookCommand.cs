using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiNet.DbOperations;

namespace WebApiNet.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int BookId { get; set;}
        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
         
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == BookId);

            if(book is  null)
                throw new InvalidOperationException("Silenecek Kitap Bulunmadı");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            
        }

        
    }

    
    
}
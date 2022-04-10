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
        private readonly int _id;
        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext dbContext,int id)
        {
            _dbContext = dbContext;
            _id = id;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == _id);

            if(book is  null)
                throw new InvalidOperationException("Kitap yok");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            
        }

        
    }

    
    
}
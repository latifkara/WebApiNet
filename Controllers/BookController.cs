using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WebApiNet.DbOperations;
using WebApiNet.BookOperations.GetBooks;
using WebApiNet.BookOperations.CreateBook;
using WebApiNet.BookOperations.UpdateBook;
using WebApiNet.BookOperations.DeleteBook;

namespace WebApiNet.AddControllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        
        readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBooks() 
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public Book GetBooks(int id) 
        {
            var book = _context.Books.Where(book=> book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {

                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {
           UpdateBookCommand update = new UpdateBookCommand(_context, id);
           try
           {
                
                update.up_Model = updateBook;
                update.Handle();
               
           }
           catch (Exception ex)
           {
               
               return BadRequest(ex.Message);
           }
           return Ok();

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand delete = new DeleteBookCommand(_context, id);
           try
           {
               delete.Handle();
           }
           catch (Exception ex)
           {
               
               return BadRequest(ex.Message);
           }
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;

using WebApiNet.DbOperations;
using WebApiNet.BookOperations.GetBooks;
using WebApiNet.BookOperations.CreateBook;
using WebApiNet.BookOperations.UpdateBook;
using WebApiNet.BookOperations.DeleteBook;
using WebApiNet.BookOperations.GetBookDetail;

namespace WebApiNet.AddControllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBooks() 
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetBooks(int id) 
        {
            GetBookDetailModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                query.BookId = id;
                GetBookCommandValidator validator = new GetBookCommandValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
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
           UpdateBookCommand update = new UpdateBookCommand(_context);
           try
           {
                
                update.up_Model = updateBook;
                update.BookId = id;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(update);
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
            DeleteBookCommand delete = new DeleteBookCommand(_context);
           try
           {
               delete.BookId = id;
               DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
               validator.ValidateAndThrow(delete);
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

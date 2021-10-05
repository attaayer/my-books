using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }


        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }


        [HttpGet("get-book-by-Id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var _book = _booksService.GetBookById(id);
            if (_book != null)
            {
                return Ok(_book);
            }
            else
            {
                return NotFound(); // This will give 404 error much better with IActionResult.
            }
            //return Ok(_book);
        }

        [HttpGet("get-a-book-by-Id/{id}")]
        public Book GetABookById(int id)
        {
            var _book = _booksService.GetBookById(id);
            //return Ok(book);

            if( _book != null)
            {
                return _book;
            }
            else
            { 
                return null; // Even this is returning 204 something but empty data but still something.
            }
        }

        [HttpPut("upd-book-by-Id/{id}")]
        public IActionResult UpdBookById(int id,[FromBody]BookVM book)
        {
            var updbook = _booksService.UpdateBookById(id, book);
            return Ok(updbook);
        }

        [HttpDelete("del-book-by-Id/{id}")]
        public IActionResult DelBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}

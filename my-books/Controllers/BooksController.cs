using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksServices _booksService;

        public BooksController(BooksServices booksServices)
        {
            _booksService = booksServices;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult GetBookById(int Id)
        {
            var BoolData = _booksService.GetBookById(Id);
            return Ok(BoolData);
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks() {
            var allBooknewData = _booksService.GetAllBook();

            return Ok(allBooknewData);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _booksService.Delete(Id);
            return Ok();
        }
        [HttpPut("{Id}")]
       public IActionResult UpdateBook (int Id, [FromBody]BookVM book)
        {
            var updatedBook = _booksService.UpdateBook(Id, book);
            return Ok(updatedBook);
        }
    }
}

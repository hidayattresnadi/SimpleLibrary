using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            var inputBook = _bookService.AddBook(book);
            if (inputBook == null) 
            {
                return BadRequest("Id should be unique");
            }
            return Ok(inputBook);
        }
        [HttpGet]
        public IActionResult GetAllBooks() 
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id) 
        {
            Book book = _bookService.GetBookById(id);
            if (book == null) 
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPut("{id}")]
        public IActionResult EditBook(Book book, int id)
        {
            var updatedBook = _bookService.UpdateBook(book, id);
            if (updatedBook == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) 
        {
            bool isDeletedBook = _bookService.DeleteBook(id);
            if (isDeletedBook == false) {
                return NotFound();
            }
            return Ok("Book is deleted");
        }
    }
}

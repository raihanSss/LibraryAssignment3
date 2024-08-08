using LibraryAssignment3.Interfaces;
using LibraryAssignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAssignment3.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = _bookService.GetAllBook();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<string> AddBook(Book book)
        {
            var result = _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, result);
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("ID buku tidak cocok");
            }

            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound("Buku tidak ditemukan");
            }

            var result = _bookService.UpdateBook(book);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteBook(int id)
        {
            var result = _bookService.DeleteBook(id);
            if (result.Contains("Buku tidak ditemukan"))
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookHistory.Models;
using BookHistory.Repository;

namespace BookHistory.Controllers
{

    public class BooksController : BooksApiControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public BooksController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task<IActionResult> GetBooks([FromQuery] QueryStringParameters bookParameters)
        {
            try
            {
                var books = await _repository.Book.GetBooksAsync(bookParameters);

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }

        public override async Task<IActionResult> GetBook(long id)
        {
            try
            {
                var book = await _repository.Book.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }

        public override async Task<IActionResult> PutBook(long id, Book book)
        {
            try
            {
                if (id != book.Id)
                {
                    return BadRequest("Book id do not match");
                }

                if (book == null)
                {
                    return BadRequest("Request body cannot be empty");
                }

                _repository.Book.UpdateBook(book);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }

        public override async Task<IActionResult> PostBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Book object is null");
                }
                _repository.Book.CreateBook(book);
                await _repository.SaveAsync();

                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
            
        }

        public override async Task<IActionResult> DeleteBook(long id)
        {
            try
            {
                var book = await _repository.Book.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                _repository.Book.DeleteBook(book);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
            
        }
    }
}

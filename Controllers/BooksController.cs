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

        public override async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await _repository.Book.GetBooksAsync();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }

        public override async Task<IActionResult> GetBookById(long id)
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

        public override async Task<IActionResult> UpdateBook(long id, Book book)
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

        public override async Task<IActionResult> CreateBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Book object is null");
                }
                _repository.Book.CreateBook(book);
                await _repository.SaveAsync();

                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
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

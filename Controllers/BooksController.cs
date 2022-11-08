using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookHistory.Models;
using BookHistory.Repository;
using AutoMapper;
using BookHistory.Models.DTOs;

namespace BookHistory.Controllers
{

    public class BooksController : BooksApiControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public BooksController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await _repository.Book.GetBooksAsync();

                return Ok(books.Select(book => _mapper.Map<BookViewDTO>(book)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }

        public override async Task<IActionResult> GetBookById(string id)
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

        public override async Task<IActionResult> UpdateBook(string id, Book book)
        {
            try
            {
                if (!string.Equals(id, book.Id))
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

        public override async Task<IActionResult> CreateBook(BookCreateDTO bookCreateDTO)
        {
            try
            {
                if (bookCreateDTO == null)
                {
                    return BadRequest("Book object is null");
                }

                var book = _mapper.Map<Book>(bookCreateDTO);
                book.Id = Guid.NewGuid().ToString();
                _repository.Book.CreateBook(book);
                await _repository.SaveAsync();

                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
            
        }

        public override async Task<IActionResult> DeleteBook(string id)
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

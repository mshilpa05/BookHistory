using BookHistory.Models;
using BookHistory.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BooksApiControllerBase: ControllerBase
    {
        [HttpGet]
        public abstract IActionResult GetBooks();

        [HttpGet("{id}")]
        public abstract Task<IActionResult> GetBookById(string id);

        [HttpPut("{id}")]
        public abstract Task<IActionResult> UpdateBook(string id, Book book);

        [HttpPost]
        public abstract Task<IActionResult> CreateBook(BookCreateDTO bookCreateDTO);


        [HttpDelete("{id}")]
        public abstract Task<IActionResult> DeleteBook(string id);
    }
}

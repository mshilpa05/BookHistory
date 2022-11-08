using BookHistory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BooksApiControllerBase: ControllerBase
    {
        [HttpGet]
        public abstract Task<IActionResult> GetBooks();

        [HttpGet("{id}")]
        public abstract Task<IActionResult> GetBookById(long id);

        [HttpPut("{id}")]
        public abstract Task<IActionResult> UpdateBook(long id, Book book);

        [HttpPost]
        public abstract Task<IActionResult> CreateBook(Book book);


        [HttpDelete("{id}")]
        public abstract Task<IActionResult> DeleteBook(long id);
    }
}

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
        public abstract Task<ActionResult<IEnumerable<Book>>> GetBook();

        [HttpGet("{id}")]
        public abstract Task<ActionResult<Book>> GetBook(long id);

        [HttpPut("{id}")]
        public abstract Task<IActionResult> PutBook(long id, Book book);

        [HttpPost]
        public abstract Task<ActionResult<Book>> PostBook(Book book);


        [HttpDelete("{id}")]
        public abstract Task<IActionResult> DeleteBook(long id);
    }
}

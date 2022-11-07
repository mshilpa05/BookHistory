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
        public abstract Task<IActionResult> GetBooks(QueryStringParameters bookParameters);

        [HttpGet("{id}")]
        public abstract Task<IActionResult> GetBook(long id);

        [HttpPut("{id}")]
        public abstract Task<IActionResult> PutBook(long id, Book book);

        [HttpPost]
        public abstract Task<IActionResult> PostBook(Book book);


        [HttpDelete("{id}")]
        public abstract Task<IActionResult> DeleteBook(long id);
    }
}

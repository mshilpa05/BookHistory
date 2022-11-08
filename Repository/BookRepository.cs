using BookHistory.Models;
using Microsoft.EntityFrameworkCore;

namespace BookHistory.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookContext bookContext)
            : base(bookContext)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return FindAll();
        }
        public async Task<Book> GetBookByIdAsync(string bookId)
        {
            return await FindByCondition(book => book.Id.Equals(bookId)).FirstAsync();
        }

        public void CreateBook(Book book)
        {
            Create(book);
        }

        public void UpdateBook(Book book)
        {
            Update(book);
        }

        public void DeleteBook(Book book)
        {
            Delete(book);
        }
    }
}

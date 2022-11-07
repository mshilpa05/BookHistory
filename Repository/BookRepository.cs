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

        public async Task<IEnumerable<Book>> GetBooksAsync(QueryStringParameters bookParameters)
        {
            return PagedList<Book>.ToPagedList(FindAll(),
                bookParameters.PageNumber,
                bookParameters.PageSize);
        }
        public async Task<Book> GetBookByIdAsync(long bookId)
        {
            return await FindByCondition(book => book.Id.Equals(bookId))
                .FirstOrDefaultAsync();
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

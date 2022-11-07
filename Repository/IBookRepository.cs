using BookHistory.Models;
using BookHistory.Repository;

namespace BookHistory.Repository
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<IEnumerable<Book>> GetBooksAsync(QueryStringParameters bookParameters);
        Task<Book> GetBookByIdAsync(long bookId);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}



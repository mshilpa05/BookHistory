using BookHistory.Models;
using BookHistory.Repository;

namespace BookHistory.Repository
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookByIdAsync(string bookId);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}



using BookHistory.Models;

namespace BookHistory.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BookContext _bookContext;
        private IBookRepository? _bookRepostory;
        private IAuditRepository? _auditRepository;

        public IBookRepository Book
        {
            get
            {
                if (_bookRepostory == null)
                {
                    _bookRepostory = new BookRepository(_bookContext);
                }

                return _bookRepostory;
            }
        }

        public IAuditRepository Audit
        {
            get
            {
                if (_auditRepository == null)
                {
                    _auditRepository = new AuditRepository(_bookContext);
                }

                return _auditRepository;
            }
        }

        public RepositoryWrapper(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task SaveAsync()
        {
            await _bookContext.SaveChangesAsync();
        }
    }
}

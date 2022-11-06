using Microsoft.EntityFrameworkCore;

namespace BookHistory.Models
{
    public class BookContext : AuditableIdentityContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = null!;
    }
}
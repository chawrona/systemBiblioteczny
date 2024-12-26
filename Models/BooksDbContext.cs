using Microsoft.EntityFrameworkCore;

namespace systemBiblioteczny.Models
{
    public class BooksDbContext : DbContext
    {

        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) {}

        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BooksStatuses { get; set; }
    }
}

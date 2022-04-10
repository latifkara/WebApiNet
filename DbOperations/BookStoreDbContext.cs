using Microsoft.EntityFrameworkCore;


namespace WebApiNet.DbOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {}
        public DbSet<Book> Books { get; set; }
    
    }
}
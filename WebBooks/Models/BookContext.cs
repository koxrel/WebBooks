using System.Data.Entity;
using WebBooks.Entities;

namespace WebBooks.Models
{
    public class BookContext : DbContext
    {
        public BookContext()
            : base("DefaultConnection") { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
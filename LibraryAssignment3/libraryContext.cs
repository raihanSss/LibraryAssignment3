using LibraryAssignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAssignment3
{
    public class libraryContext : DbContext
    {

        public libraryContext(DbContextOptions<libraryContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

    }
}

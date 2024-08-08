using LibraryAssignment3.Interfaces;
using LibraryAssignment3.Models;

namespace LibraryAssignment3.Services
{
    namespace Library.Services
    {
        public class BookService : IBookService
        {
            private readonly libraryContext _context;

            public BookService(libraryContext context)
            {
                _context = context;
            }

            public string AddBook(Book book)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return "Buku berhasil ditambahkan";
            }

            public IEnumerable<Book> GetAllBook()
            {
                return _context.Books.ToList();
            }

            public Book GetBookById(int id)
            {
                return _context.Books.FirstOrDefault(b => b.Id == id);
            }

            public string UpdateBook(Book book)
            {
                var existingBook = _context.Books.FirstOrDefault(b => b.Id == book.Id);
                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.Author = book.Author;
                    existingBook.PublicationYear = book.PublicationYear;
                    existingBook.ISBN = book.ISBN;
                    _context.SaveChanges();
                    return "Data buku berhasil diubah";
                }
                return "Buku tidak ditemukan";
            }

            public string DeleteBook(int id)
            {
                var book = _context.Books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                    return "Data buku berhasil dihapus";
                }
                return "Buku tidak ditemukan";
            }
        }
    }
}

using LibraryData;
using LibraryData.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class BookService : IBook
    {

        private LibraryContext _context;
        
        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public void Edit(Book editedBook)
        {
            var book = _context.Books.FirstOrDefault(item => item.ID == editedBook.ID);

            book.Author = editedBook.Author;
            book.Title = editedBook.Title;
            book.Description = editedBook.Description;
            book.Year = editedBook.Year;

            _context.Update(book);
            _context.SaveChanges();
        }

        public void Add(Book newBook)
        {
            _context.Add(newBook);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public void Remove(int id)
        {
            Book book = new Book() { ID = id };
            _context.Books.Attach(book);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Book GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(book => book.ID == id);
        }

        public string GetAuthor(int id)
        {
            return GetAll()
                .FirstOrDefault(book => book.ID == id)
                .Author;
        }


        public string GetDescription(int id)
        {
            return GetAll()
                .FirstOrDefault(book => book.ID == id)
                .Description;
        }

        public string GetTitle(int id)
        {
            return GetAll()
                .FirstOrDefault(book => book.ID == id)
                .Title;
        }

        public int GetYear(int id)
        {
            return GetAll()
                .FirstOrDefault(book => book.ID == id)
                .Year;
        }
    }
}

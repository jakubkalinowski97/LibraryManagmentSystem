using System.Linq;
using Library.Models;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {

        private IBook _books;
        private ICheckout _checkouts;
        public BooksController(IBook books, ICheckout checkouts)
        {
            _books = books;
            _checkouts = checkouts;
        }

        public IActionResult Index()
        {
            var bookModels = _books.GetAll();
            var listResult = bookModels.Select(result => new BookVM
            {
                ID = result.ID,
                Title = result.Title,
                Author = result.Author
            });

            var model = new ListBooks()
            {
                Books = listResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var book = _books.GetById(id);

            var model = new BookDetailVM()
            {
                ID = id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                IsCheckouted = book.IsCheckouted,
                Description = book.Description,
                LastCheckout = _checkouts.GetLastCheckout(id),
                CheckoutHistory = _checkouts.GetCheckoutHistory(id)
            };
            return View(model);
        }

        public IActionResult Checkout(int id)
        {
            var book = _books.GetById(id);

            var model = new CheckoutVM()
            {
                BookId = id,
                Title = book.Title,
                PatronId = "",
                IsCheckedOut = book.IsCheckouted
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult HandleCheckout(int bookId, int patronId)
        {
            _checkouts.CheckOutBook(bookId, patronId);
            return RedirectToAction("Detail", new { id = bookId });
        }

        public IActionResult HandleCheckin(int id)
        {
            _checkouts.CheckInBook(id);
            return RedirectToAction("Detail", new { id = id });
        }

        public IActionResult Remove(int id)
        {
            _books.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            Book book = new Book();
            return View(book);
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            Book newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Year = book.Year,
                IsCheckouted = false
            };

            if (ModelState.IsValid)
            {
                _books.Add(newBook);
                return RedirectToAction("Index");
            }

            return View(newBook);
        }

        public IActionResult Edit(int id)
        {
            var book = _books.GetById(id);

            var model = new Book()
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                Description = book.Description,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                Book editedBook = new Book()
                {
                    ID = book.ID,
                    Title = book.Title,
                    Author = book.Author,
                    Year = book.Year,
                    Description = book.Description
                };
                _books.Edit(editedBook);
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}
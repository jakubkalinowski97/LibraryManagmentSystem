using LibraryData;
using LibraryData.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    public class CheckoutService : ICheckout
    {

        private LibraryContext _context;

        public CheckoutService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Checkout checkout)
        {
            _context.Add(checkout);
            _context.SaveChanges();
        }

        public IEnumerable<Checkout> GetAll()
        {
            return _context.Checkouts;
        }

        public Checkout GetById(int id)
        {
            return GetAll().FirstOrDefault(checkout => checkout.ID == id);
        }

        public void CheckInBook(int bookId)
        {
            var now = DateTime.Now;
            var book = _context.Books.FirstOrDefault(b => b.ID == bookId);
            book.IsCheckouted = false;
            _context.Update(book);

            var history = _context.CheckoutsHistory
                .FirstOrDefault(h =>
                    h.Book.ID == bookId
                    && h.CheckedIn == null);
            if (history != null)
            {
                _context.Update(history);
                history.CheckedIn = now;
            }

            _context.SaveChanges();
        }

        public void CheckOutBook(int bookId, int patronId)
        {
            var now = DateTime.Now;
            var book = _context.Books.FirstOrDefault(b => b.ID == bookId);
            book.IsCheckouted = true;
            var patron = _context.Patrons.FirstOrDefault(p => p.ID == patronId);

            var checkout = new Checkout
            {
                Patron = patron,
                Book = book,
                Since = now,
                Until = now.AddDays(7)
            };

            _context.Add(checkout);

            var checkoutHistory = new CheckoutHistory
            {
                CheckedOut = now,
                Book = book,
                Patron = patron
            };

            _context.Add(checkoutHistory);
            _context.SaveChanges();
        }
        
        public Checkout GetLastCheckout(int bookId)
        {
            return _context.Checkouts
                .Where(x => x.Book.ID == bookId)
                .OrderByDescending(x => x.Since)
                .FirstOrDefault();
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutsHistory
                .Include(x => x.Patron)
                .Where(x => x.Book.ID == id);
        }

    }
}

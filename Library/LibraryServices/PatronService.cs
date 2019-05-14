using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryServices
{
    public class PatronService : IPatron
    {
        private LibraryContext _context;

        public PatronService(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Patron newPatron)
        {
            _context.Add(newPatron);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            Patron patron = new Patron() { ID = id };
            _context.Patrons.Attach(patron);
            _context.Patrons.Remove(patron);
            _context.SaveChanges();
        }

        public Patron Get(int id)
        {
            return _context.Patrons
                .FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons;
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId)
        {
            return _context.CheckoutsHistory
                .Include(checkout => checkout.Book)
                .Where(checkout => checkout.Patron.ID == patronId)
                .OrderByDescending(checkout => checkout.CheckedOut);
        }

        public IEnumerable<Checkout> GetCheckouts(int id)
        {
            var patronId = Get(id).ID;
            return _context.Checkouts
                .Include(checkout => checkout.Book)
                .Where(checkout => checkout.Patron.ID == patronId);
        }
    }
}

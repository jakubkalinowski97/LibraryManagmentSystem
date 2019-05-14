using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ICheckout
    {
        IEnumerable<Checkout> GetAll();
        Checkout GetById(int id);
        void Add(Checkout checkout);
        void CheckOutBook(int bookId, int patronId);
        void CheckInBook(int bookId);
        Checkout GetLastCheckout(int bookId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
    }
}

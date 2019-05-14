﻿using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IPatron
    {
        IEnumerable<Patron> GetAll();
        Patron Get(int id);
        void Add(Patron patron);
        void Remove(int id);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId);
        IEnumerable<Checkout> GetCheckouts(int id);
    }
}

using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookDetailVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public bool IsCheckouted { get; set; }
        public Checkout LastCheckout { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }
    }
}

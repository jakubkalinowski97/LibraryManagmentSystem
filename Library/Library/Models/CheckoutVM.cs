using LibraryData.Models;
using System;

namespace Library.Models
{
    public class CheckoutVM
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string PatronId { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}

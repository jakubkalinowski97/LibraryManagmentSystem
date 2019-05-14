using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class PatronDetailVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Since { get; set; }
        public IEnumerable<Checkout> Checkouts { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutsHistory { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class CheckoutHistory
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public Patron Patron { get; set; }
        [Required]
        public DateTime CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
    }
}

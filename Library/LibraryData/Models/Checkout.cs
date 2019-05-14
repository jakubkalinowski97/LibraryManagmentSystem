using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class Checkout
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public Patron Patron { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
    }
}

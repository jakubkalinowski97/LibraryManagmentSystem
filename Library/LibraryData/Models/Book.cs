using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Title length can't be more than 60.")]
        public string Title { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Author length can't be more than 30.")]
        public string Author { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Description length can't be more than 1000.")]
        public string Description { get; set; }

        [Required]
        public int Year { get; set; }
        public bool IsCheckouted { get; set; }
    }
}

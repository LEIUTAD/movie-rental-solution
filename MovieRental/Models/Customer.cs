using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}

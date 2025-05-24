namespace MovieRental.Dto
{
    public class RentalDto
    {
        public int MovieId { get; set; }
        public int DaysRented { get; set; }
        public int CustomerId { get; set; }
        public string PaymentMethod { get; set; }
    }
}

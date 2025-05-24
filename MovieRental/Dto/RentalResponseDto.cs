namespace MovieRental.Dto
{
    public class RentalResponseDto
    {
        public int Id { get; set; }
        public int DaysRented { get; set; }
        public string MovieTitle { get; set; }
        public string CustomerName { get; set; }
        public string PaymentMethod { get; set; }
    }
}

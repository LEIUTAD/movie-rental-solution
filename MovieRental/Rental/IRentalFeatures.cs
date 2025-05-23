namespace MovieRental.Rental;

public interface IRentalFeatures
{
	Task <Rental> Save(Rental rental);
	Task<List<Rental>> GetRentalsByCustomerName(string customerName);
}
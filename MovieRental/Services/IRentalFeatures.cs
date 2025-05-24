namespace MovieRental.Services;
using MovieRental.Models;

public interface IRentalFeatures
{
    Task<Rental> Save(Rental rental);
    Task<List<Rental>> GetRentalsByCustomerName(string customerName);
}
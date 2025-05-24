using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Models;

namespace MovieRental.Services
{
    public class RentalFeatures : IRentalFeatures
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public RentalFeatures(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }

        //TODO: make me async :(
        public async Task<Rental> Save(Rental rental)
        {
            _movieRentalDb.Rentals.Add(rental);
            await _movieRentalDb.SaveChangesAsync();
            return rental;
        }

        //TODO: finish this method and create an endpoint for it
        public async Task<List<Rental>> GetRentalsByCustomerName(string customerName)
        {
            return await _movieRentalDb.Rentals
                .Include(r => r.Customer)
                .Where(r => r.Customer.Name.ToLower() == customerName.ToLower())
                .ToListAsync();
        }

    }
}

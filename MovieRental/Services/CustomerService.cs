using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Dto;
using MovieRental.Models;

namespace MovieRental.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly MovieRentalDbContext _db;

        public CustomerService(MovieRentalDbContext db)
        {
            _db = db;
        }

        public async Task<Customer> CreateCustomerAsync(CustomerDto dto)
        {
            var customer = new Customer { Name = dto.Name };
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _db.Customers.ToListAsync();
        }
    }
}

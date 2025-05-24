using MovieRental.Dto;
using MovieRental.Models;


namespace MovieRental.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(CustomerDto dto);
        Task<List<Customer>> GetAllCustomersAsync();
    }
}
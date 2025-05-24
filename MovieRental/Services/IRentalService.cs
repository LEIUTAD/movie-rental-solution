using MovieRental.Dto;
using MovieRental.Models;

namespace MovieRental.Services
{
    public interface IRentalService
    {
        Task<Rental> CreateRentalAsync(RentalDto dto);
        Task<List<RentalResponseDto>> GetRentalsByCustomerNameAsync(string customerName);
    }
}
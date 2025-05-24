using Microsoft.AspNetCore.Mvc;
using MovieRental.Dto;
using MovieRental.Services;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _features;

        public RentalController(IRentalService features)
        {
            _features = features;
        }

        [HttpGet("by-customer")]
        public async Task<IActionResult> GetByCustomerName([FromQuery] string name)
        {
            var rentals = await _features.GetRentalsByCustomerNameAsync(name);
            if (rentals == null || !rentals.Any())
            {
                throw new Exception($"No rentals found for customer '{name}'.");
            }
            return Ok(rentals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental([FromBody] RentalDto rentalDto)
        {
            var rental = await _features.CreateRentalAsync(rentalDto);
            return Ok(rental);
        }
    }
}

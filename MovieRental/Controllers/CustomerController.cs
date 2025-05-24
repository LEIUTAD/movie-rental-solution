using Microsoft.AspNetCore.Mvc;
using MovieRental.Dto;
using MovieRental.Services;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto dto)
        {
            var customer = await _service.CreateCustomerAsync(dto);
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllCustomersAsync();
            return Ok(customers);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MovieRental.Services;
using MovieRental.Dto;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _features;

        public MovieController(IMovieService features)
        {
            _features = features;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movies = await _features.GetAllAsync();
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieDto dto)
        {
            var movie = await _features.SaveAsync(dto);
            return Ok(movie);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MovieRental.Services;
using MovieRental.Models;

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
        public IActionResult Post([FromBody] Movie movie)
        {
	        return Ok(_features.Save(movie));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Models;

namespace MovieRental.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public MovieService(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }

        public Movie Save(Movie movie)
        {
            _movieRentalDb.Movies.Add(movie);
            _movieRentalDb.SaveChanges();
            return movie;
        }

        // TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?
        public async Task<List<Movie>> GetAllAsync()
        {
            return await _movieRentalDb.Movies.ToListAsync();
        }


    }
}

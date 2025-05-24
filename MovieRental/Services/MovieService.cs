using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Dto;
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

        public async Task<Movie> SaveAsync(MovieDto dto)
        {
            // Verifica se o título já existe (ignorando maiúsculas/minúsculas)
            bool exists = await _movieRentalDb.Movies
                .AnyAsync(m => m.Title.ToLower() == dto.Title.ToLower());

            if (exists)
                throw new ApplicationException($"A movie with the title '{dto.Title}' already exists.");

            var movie = new Movie { Title = dto.Title };
            _movieRentalDb.Movies.Add(movie);
            await _movieRentalDb.SaveChangesAsync();
            return movie;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _movieRentalDb.Movies.ToListAsync();
        }
    }
}
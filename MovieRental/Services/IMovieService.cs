using MovieRental.Models;
namespace MovieRental.Services;

public interface IMovieService
{
    Movie Save(Movie movie);
    Task<List<Movie>> GetAllAsync();
}
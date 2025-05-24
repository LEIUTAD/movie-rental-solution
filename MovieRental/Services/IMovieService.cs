using MovieRental.Dto;
using MovieRental.Models;
namespace MovieRental.Services;

public interface IMovieService
{
    Task<Movie> SaveAsync(MovieDto dto);
    Task<List<Movie>> GetAllAsync();
}
using MovieRental.Models;
namespace MovieRental.Services;

public interface IMovieFeatures
{
    Movie Save(Movie movie);
    List<Movie> GetAll();
}
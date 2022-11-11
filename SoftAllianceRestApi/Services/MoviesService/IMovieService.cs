using Microsoft.AspNetCore.Mvc;
using SoftAllianceRestApi.Models;

namespace SoftAllianceRestApi.Services.MoviesService
{
    public interface IMovieService
    {
        Task AddMovieAsync(Movie movie);
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetMovieByIdAsync(int? movieId);
        public Task<Movie> EditMovieByIdAsync(int? movieId, Movie movie);
        public Task<bool> DeleteMovieByIdAsync(int? movieId);

    }
}

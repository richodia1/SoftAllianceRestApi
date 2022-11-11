using Microsoft.EntityFrameworkCore;
using SoftAllianceRestApi.DbContexts;
using SoftAllianceRestApi.Models;

namespace SoftAllianceRestApi.Services.MoviesService
{
    public class MovieService : IMovieService
    {
        private readonly MovieInfoContext _context;

        public MovieService(MovieInfoContext context)
        {
            _context = context;
        }
        public async Task AddMovieAsync(Movie movie)
        {
                _context.Add(movie);
                await _context.SaveChangesAsync();
               
        }

        public async Task<bool> DeleteMovieByIdAsync(int? movieId)
        {
            var movie = await _context.movies.FindAsync(movieId);
            if (movie != null)
            {
                _context.movies.Remove(movie);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
           
        }

        public async Task<Movie?> EditMovieByIdAsync(int? movieId, Movie movie)
        {
            var existedMovie = await _context.movies.FindAsync(movieId);

            if (existedMovie != null)
            {
                existedMovie.TicketPrice = movie.TicketPrice;
                existedMovie.Rating = movie.Rating;
                existedMovie.Photo = movie.Photo;
                existedMovie.Name = movie.Name;
                existedMovie.ReleaseDate = movie.ReleaseDate;
                existedMovie.Description = movie.Description;
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }

            return existedMovie;
         }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
           return await _context.movies.Include(g => g.Genres).ToListAsync();
            
        }

        public async Task<Movie?> GetMovieByIdAsync(int? movieId)
        {
         return await _context.movies
               .FirstOrDefaultAsync(m => m.Id == movieId);

             
        }
    }
}

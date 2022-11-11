using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftAllianceRestApi.Infrastructure;
using SoftAllianceRestApi.Models;
using SoftAllianceRestApi.Models.modelDto;
using SoftAllianceRestApi.Models.modelDtos;
using SoftAllianceRestApi.Services;
using SoftAllianceRestApi.Services.MoviesService;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftAllianceRestApi.Controllers
{
  
        [ApiController]
        [Authorize]
        //[ApiVersion("1.0")]
        [Route("api/v1/movies")]
        public class MoviesController : ControllerBase
        {
        private readonly ILogger<MoviesController> _logger;

        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        const int maxMoviePageSize = 20;

        public MoviesController(IMovieService movieService,
                IMapper mapper, ILogger<MoviesController> logger)
            {
            _movieService = movieService ??
                    throw new ArgumentNullException(nameof(movieService));
                _mapper = mapper ??
                    throw new ArgumentNullException(nameof(mapper));
            _logger = logger ??
                   throw new ArgumentNullException(nameof(logger));

        }

        [HttpPut("{movieId}")]
        public async Task<ActionResult> UpdateMovies(int? movieId,MovieForCreateUpdateDto moviedto)
        {

            if (movieId == null && moviedto == null)
            {
                return BadRequest();
            }
            var originalMovie = _mapper.Map<Movie>(moviedto);

            var result = await _movieService.EditMovieByIdAsync(movieId, originalMovie);

            return Ok(result);
        }
        private Movie MapTODto(MovieForCreateUpdateDto dto)
        {
            Movie mov = new Movie();
            mov.Photo = dto.Photo;
            mov.Rating = dto.Rating;
            mov.TicketPrice = dto.TicketPrice;
            mov.Description = dto.Description;
            mov.ReleaseDate = dto.ReleaseDate;
            mov.Country = dto.Country;
            mov.Name = dto.Name;
            if (dto.genry.Any())
            {
                foreach( var ger in dto.genry)
                {
                    Genre gen = new Genre();
                    gen.Name = ger;
                    mov.Genres.Add(gen);
                }
            }
           // mov.Genres.Add(new Genre())

            return mov;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateMovie(MovieForCreateUpdateDto moviedto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var originalmovie = MapTODto(moviedto);

             await _movieService.AddMovieAsync(originalmovie);


            return CreatedAtAction(nameof(CreateMovie), new { id = originalmovie.Id }, originalmovie);
        }

        [HttpGet]
            public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllMovies()
            { 

                return Ok(_mapper.Map<IEnumerable<MovieDto>>(await _movieService.GetAllMoviesAsync()));
            }
        [HttpDelete("/{movieId}")]
        public async Task<ActionResult<bool>> DeleteByID(int? movieId)
        {

            await _movieService.DeleteMovieByIdAsync(movieId);
            return NoContent();
        }

        /// <summary>
        /// Get a movie by id
        /// </summary>
        /// <param name="movieId">The id of the movie to get</param>
        /// <param name="includePointsOfInterest">Whether or not to include the genre</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested movie</response>
        [HttpGet("movieid/{movieId}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<MovieDto>> GetMovieBymovieId(int movieId)
            {
                var movie = await _movieService.GetMovieByIdAsync(movieId);
                if (movie == null)
                {
                    return NotFound();
                }
                    return Ok(_mapper.Map<MovieDto>(movie));
              
            }
        }

}

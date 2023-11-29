using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesService _moviesService;

        public MovieController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _moviesService.getAllMovies();
            return Ok(movies);
        }

        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = _moviesService.getmovieByID(id);
            return Ok(movie);
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie([FromQuery] int id, [FromBody] MovieVM movie)
        {
            var updatedMovie = _moviesService.updateMovie(id, movie);
            return Ok(updatedMovie);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            _moviesService?.deleteMovie(id);
            return Ok();
        }


        [HttpPost]
        public IActionResult AddMovie(MovieVM movie)
        {
            _moviesService.addMovie(movie);
            return Ok();
        }



    }
}

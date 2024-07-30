using Microsoft.AspNetCore.Mvc;
using MyLetterBoxd.Service;
using System.Threading.Tasks;

namespace MyLetterBoxd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDBController : ControllerBase
    {
        private readonly TMDBService _tmdbService;

        public TMDBController(TMDBService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("movies")]
        public async Task<IActionResult> FetchPopularMovies()
        {
            // Fetch popular movies from TMDB
            var movies = await _tmdbService.GetPopularMoviesAsync();

            if (movies == null)
            {
                return BadRequest("Failed to fetch movies from TMDB.");
            }

            // Save movies to the database
            await _tmdbService.SaveMoviesAsync(movies);

            return Ok("Movies fetched and saved successfully.");
        }
    }
}
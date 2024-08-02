using Microsoft.AspNetCore.Mvc;
using MyLetterBoxd.Models;
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
            try {
                await _tmdbService.GetPopularMoviesAsync();
                return Ok("Movies fetched and saved successfully.");
            } 
            catch (Exception ex)
            {
                return BadRequest($"Failed to fetch movies from TMDB. {ex.Message}");
            }
        }

        [HttpGet("genres")]
        public async Task<IActionResult> FetchGenres()
        {
            var genres = await _tmdbService.GetGenresAsync();

            if (genres == null)
            {
                return BadRequest("Failed to fetch movies from TMDB.");
            }

            await _tmdbService.SaveGenresAsync(genres);

            return Ok("Movies fetched and saved successfully.");
        }
    }
}
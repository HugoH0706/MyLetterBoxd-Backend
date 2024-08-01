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
            var movies = await _tmdbService.GetPopularMoviesAsync();

            if (movies == null)
            {
                return BadRequest("Failed to fetch movies from TMDB.");
            }

            // await _tmdbService.SaveMoviesAsync(movies);

            return Ok("Movies fetched and saved successfully.");
        }

        // [HttpGet("genres")]
        // public async Task<IActionResult> FetchAllGenres()
        // {
        //     List<Genre> genres = await _tmdbService.GetGenresAsync();

        //     if (genres == null)
        //     {
        //         return BadRequest("Failed to fetch movies from TMDB.");
        //     }
            
        //     foreach(Genre genre in genres)
        //     {
        //         Console.WriteLine($"ID: {genre.Id}, Name: {genre.Name}");
        //     }

        //     // await _tmdbService.SaveGenresAsync(genres);

        //     return Ok("Movies fetched and saved successfully.");
        // }
    }
}
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

            foreach(var film in movies)
            {
                Console.WriteLine($"Title: {film.Title}");
                Console.WriteLine($"Overview: {film.Description}");
                Console.WriteLine($"Release Date: {film.ReleaseDate}");
                Console.WriteLine($"Vote Average: {film.Rating}");
                //Console.WriteLine("Genre IDs: " + string.Join(", ", film.Genre.Select(g => g.Name)));
                //Console.WriteLine("Actors: " + string.Join(", ", film.Actors.Select(a => a.Name + "(" + a.Character + ")")));
                //Console.WriteLine("Directors: " + string.Join(", ", film.Directors.Select(a => a.Name)));
                Console.WriteLine();
            }

            await _tmdbService.SaveMoviesAsync(movies);

            return Ok("Movies fetched and saved successfully.");
        }
    }
}
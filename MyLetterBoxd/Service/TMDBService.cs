using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLetterBoxd.Database;
using MyLetterBoxd.Models;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace MyLetterBoxd.Service
{
    public class TMDBService
    {
        private readonly MyLetterBoxdContext _context;
        private readonly string _apiKey = "";

        public TMDBService(MyLetterBoxdContext context)
        {
            _context = context;
        }

        public async Task<List<Entertainment>> GetPopularMoviesAsync()
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4YTZmODM3MjgxYzBiOWUzYWQyMWJlY2Q4ZDg1ZWY5MyIsIm5iZiI6MTcyMjMzMTU5Mi43NTU1MjEsInN1YiI6IjY2YTc5YjQxNDU5NjEwODkzNmM2ODhhZiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.gUW1naYK8RZHuMPluMYjPbq0-zVd0qsK4cwpid0x1x4");
            var response = await client.GetAsync(request);
            Console.WriteLine(response.Content);
            
            var tmdbResponse = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(tmdbResponse);
            // Console.WriteLine(response);

            // if (!response.IsSuccessful)
            // {
            //     return null;
            // }

            // var movies = JObject.Parse(response.Content)["results"].ToObject<List<TmdbMovie>>();
            // Console.WriteLine(movies);
            var entertainments = new List<Entertainment>();
            
            // foreach (var movie in movies)
            // {
            //     // Check if the movie already exists in the database
            //     if (!_context.Set<Entertainment>().Any(e => e.Title == movie.Title))
            //     {
            //         entertainments.Add(new Film
            //         {
            //             Title = movie.Title,
            //             Genre = string.Join(", ", movie.GenreIds), // Simplified, should map genre IDs to names
            //             Rating = Rating.FIVE // Placeholder, you might want to map TMDb rating to your Rating enum
            //         });
            //     }
            // }

            return entertainments;
        }

        public async Task SaveMoviesAsync(List<Entertainment> movies)
        {
            _context.Set<Entertainment>().AddRange(movies);
            await _context.SaveChangesAsync();
        }
    }

    public class TmdbMovie
    {
        public string Title { get; set; }
        public List<int> GenreIds { get; set; }
    }
}

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

        public TMDBService(MyLetterBoxdContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetGenresAsync()
        {
            // Get all genres with their TMDB IDs
            var options = new RestClientOptions("https://api.themoviedb.org/3/genre/movie/list?language=en"); 
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", Environment.GetEnvironmentVariable("API_KEY"));
            
            var response = await client.GetAsync(request);
            JObject parsedResponse = JObject.Parse(response.Content);
            List<Genre> genres = parsedResponse["genres"].ToObject<List<Genre>>();

            return genres;
        }

        public async Task<List<Cast>> GetActorsDirectorsAsync(int movie_id)
        {
            // Use movie_id to get JSON including cast(Actors) and crew(Director), extract useful data and store in List<Cast>
            string API_ENDPOINT = "https://api.themoviedb.org/3/movie/" + movie_id + "/credits?language=en-US";
            var options = new RestClientOptions(API_ENDPOINT); 
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", Environment.GetEnvironmentVariable("API_KEY"));
            
            var response = await client.GetAsync(request);
            JObject parsedResponse = JObject.Parse(response.Content);

            JToken castToken = parsedResponse["cast"];
            List<Cast> cast = new List<Cast>();

            cast = castToken
                .Where(c => c["known_for_department"] != null && c["known_for_department"].Value<string>() == "Acting" )
                .Select(c => new Cast
                {
                    Name = c.Value<string>("name"),
                    Character = c.Value<string>("character"),
                    Role = c.Value<string>("known_for_department")
                })
                .ToList();

            JToken crewToken = parsedResponse["crew"];
            var directors = crewToken 
                .Where(c => c["known_for_department"] != null && c["known_for_department"].Value<string>() == "Directing" &&
                            c["job"] != null && c["job"].Value<string>() == "Director")
                .Select(c => new Cast
                {
                    Name = c.Value<string>("name"),
                    Character = null,
                    Role = c.Value<string>("known_for_department")
                })
                .ToList();

            cast.AddRange(directors);
            return cast;
        }

        public async Task<List<Entertainment>> GetPopularMoviesAsync()
        {
            // Get top rated movies, for each movie link genre id to genre and find corresponding actors and director
            var options = new RestClientOptions("https://api.themoviedb.org/3/movie/top_rated?language=en-US&page=1"); 
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", Environment.GetEnvironmentVariable("API_KEY"));
            var response = await client.GetAsync(request);
            
            List<Genre> availableGenres = await GetGenresAsync();
            var entertainments = new List<Entertainment>();
            
            JObject parsedResponse = JObject.Parse(response.Content);
            JToken resultsToken = parsedResponse["results"];
            if (resultsToken != null)
            {
                List<Film> films = resultsToken.ToObject<List<Film>>();
                foreach (var result in resultsToken)
                {
                    List<Cast> availableCast = await GetActorsDirectorsAsync(result.Value<int>("id"));
                    var film = new Film
                    {
                        ID = result.Value<int>("id"),
                        Title = result.Value<string>("title"),
                        Description = result.Value<string>("overview"),
                        ReleaseDate = result.Value<string>("release_date"),
                        Rating = result.Value<double>("vote_average"),
                        //Genre = result["genre_ids"].Select(id => availableGenres.FirstOrDefault(g => g.Id == (int)id)).Where(g => g != null).ToList(),
                        // Actors = availableCast.Where(c => c.Role == "Acting").ToList(),
                        // Directors = availableCast.Where(c => c.Role == "Directing").ToList()
                    };
                    entertainments.Add(film);
                }
            }
            else
            {
                Console.WriteLine("No results found in the response.");
            }

            return entertainments;
        }

        public async Task SaveMoviesAsync(List<Entertainment> movies)
        {
            _context.Set<Entertainment>().AddRange(movies);
            await _context.SaveChangesAsync();
        }

        // https://api.themoviedb.org/3/movie/movie_id/credits?language=en-US gets whole cast --> first "cast" --> "known_for_department": "Acting" | "name":"Tim Robbins" | "character":"Andy Dufresne"
            //                                                                                   "known_for_department":"Directing" | "name":"Frank Darabont"
            // https://api.themoviedb.org/3/movie/top_rated?language=en-US&page=1&append_to_response=credits get popular movies per page --> "genre_ids" | "original_title" | "overview" | 
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLetterBoxd.Database;
using MyLetterBoxd.Models;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;


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
            var cast = new List<Cast>();

            cast = castToken
                .Where(c => c["known_for_department"] != null && c["known_for_department"].Value<string>() == "Acting" )
                .Take(10)
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
            await SaveCastAsync(cast);

            foreach (var c in cast)
            {
                var savedCast = await _context.Casts.FirstOrDefaultAsync(x => x.Name == c.Name && x.Role == c.Role);
                if (savedCast != null)
                {
                    c.ID = savedCast.ID;
                }
            }

            return cast;
        }

        public async Task GetPopularMoviesAsync()
        {
            // Get top rated movies, for each movie link genre id to genre and find corresponding actors and director
            var options = new RestClientOptions("https://api.themoviedb.org/3/movie/top_rated?language=en-US&page=1"); 
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", Environment.GetEnvironmentVariable("API_KEY"));
            
            var response = await client.GetAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception("Failed to fetch movies from TMDB.");
            }

            var entertainments = new List<Entertainment>();
            var ge = new List<GenreEntertainment>();
            var ce = new List<CastEntertainment>();
            
            JObject parsedResponse = JObject.Parse(response.Content);
            JToken resultsToken = parsedResponse["results"];
            if (resultsToken != null)
            {
                foreach (var result in resultsToken)
                {
                    var film = new Film
                    {
                        Title = result.Value<string>("title"),
                        Description = result.Value<string>("overview"),
                        ReleaseDate = result.Value<string>("release_date"),
                        Rating = result.Value<double>("vote_average"),
                    };

                    var existingFilm = await _context.Entertainments.FirstOrDefaultAsync(f => f.Title == film.Title && f.ReleaseDate == film.ReleaseDate);
                    if(existingFilm != null)
                    {
                        continue;
                    }
                    _context.Entertainments.Add(film);
                    entertainments.Add(film);
                }
                await _context.SaveChangesAsync();

                foreach(var result in resultsToken)
                { 
                    var film = entertainments.First(f => f.Title == result.Value<string>("title"));
                    var genreIds = result["genre_ids"].Select(id => (int)id).ToList();
                    foreach(var genreId in genreIds)
                    {
                        var genreEntertainment = new GenreEntertainment
                        {
                            GenreID = genreId,
                            EntertainmentID = film.ID
                        };
                        ge.Add(genreEntertainment);
                    }
                    
                    List<Cast> availableCast = await GetActorsDirectorsAsync(result.Value<int>("id"));
                    foreach(var cast in availableCast)
                    {
                        var castEntertainment = new CastEntertainment
                        {
                            CastID = cast.ID,
                            EntertainmentID = film.ID
                        };
                        ce.Add(castEntertainment);
                    }
                }
                await SaveGenreEntertainmentAsync(ge);
                await SaveCastEntertainmentAsync(ce);
            }
            else
            {
                Console.WriteLine("No results found in the response.");
            }
        }

        public async Task SaveGenreEntertainmentAsync(List<GenreEntertainment> ge)
        {
            var existingGE = await _context.GenreEntertainments.ToListAsync();
            var newGE = ge
                .Where(g => !existingGE.Any(eg => eg.GenreID == g.GenreID && eg.EntertainmentID == g.EntertainmentID)).ToList();

            if(newGE.Any())
            {
                _context.Set<GenreEntertainment>().AddRange(newGE);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveCastEntertainmentAsync(List<CastEntertainment> ce)
        {
            var existingCE = await _context.CastEntertainments.ToListAsync();
            var newCE = ce
                .Where(c => !existingCE.Any(ec => ec.CastID == c.CastID && ec.EntertainmentID == c.EntertainmentID)).ToList();

            if(newCE.Any())
            {
                _context.Set<CastEntertainment>().AddRange(newCE);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveCastAsync(List<Cast> casts)
        {
            var existingCast = await _context.Casts.ToListAsync();
            var newCast = casts
                .Where(c => !existingCast.Any(ec => ec.Name == c.Name)).ToList();

            if(newCast.Any())
            {
                _context.Set<Cast>().AddRange(newCast);
                await _context.SaveChangesAsync();
            }
        }
        public async Task SaveGenresAsync(List<Genre> genres)
        {
            var existingGenres = await _context.Genres.ToListAsync();
            var newGenres = genres
                .Where(g => !existingGenres.Any(eg => eg.Name == g.Name)).ToList();

            if(newGenres.Any())
            {
                _context.Set<Genre>().AddRange(newGenres);
                await _context.SaveChangesAsync();
            }
        }
    }
}

# MyLetterBoxd-Backend
MyLetterBoxd is an replica of the existing app Letterboxd.
Letterboxd is an app used to view, rate and read reviews about movies.
Furthermore, you are able to create a watchlist of movies you would like to see in the future and it enables you to keep track of all movies you've watched alongside your rating of that movie.

# Functionalities
1. View movies (Description, title, director, actors, average rating, genre)
2. Read reviews about movies
4. Rate a movie
5. Add movie to your watchlist
6. Add movie with rating, to your watched movies
 
# Updating Database
1. dotnet ef migrations add {UPDATE_NAME}
2. dotnet ef database update

# Delete Database (for testing)
1. dotnet ef database drop --force

# Table Per Hierarchy
Entity Framework Core will represent an object-oriented hierarchy in a single table that takes the name of the base class and includes a "discriminator" column to identify the specific type for each row. 
In our case we have Entertainment (abstract parent class), Film and Serie (concrete child classes). Only a table Entertainment is present in the database containing Film and Serie instances.
Our discriminator is called EntertainmentType, which is either 1 (Film) or 2 (Serie).

# Run Program
1. dotnet run


# TMDB
TMDB is a large database for movies and tv shows. It allows developers to create an API key which is used
to connect to TMDB's API and fetch movies and series. Example of a request using RestSharp:
using RestSharp;

```
var options = new RestClientOptions("https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc");
var client = new RestClient(options);
var request = new RestRequest("");
request.AddHeader("accept", "application/json");
request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4YTZmODM3MjgxYzBiOWUzYWQyMWJlY2Q4ZDg1ZWY5MyIsIm5iZiI6MTcyMjMzMTYxMy4zMjEyODQsInN1YiI6IjY2YTc5YjQxNDU5NjEwODkzNmM2ODhhZiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.I-ZLf5ymqNPZTgPlaNsVYDU5kYb0_00M5ScUe5c2Yx4");
var response = await client.GetAsync(request);

Console.WriteLine("{0}", response.Content);
```

API endpoints to retrieve information from TMDB:
1. https://api.themoviedb.org/3/movie/movie_id/credits?language=en-US --> get cast (actors) of a specific movie
2. https://api.themoviedb.org/3/movie/top_rated?language=en-US&page=1 --> get most popular movies (on page 1)
3. https://api.themoviedb.org/3/genre/movie/list?language=en --> get all genre-id tuples  
4. https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc --> get recent movies from best rated to worst rated
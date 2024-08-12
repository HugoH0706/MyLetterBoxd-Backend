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
1. https://api.themoviedb.org/3/movie/movie_id/credits?language=en-US --> get cast and crew (specifically actors and director) of a specific movie
2. https://api.themoviedb.org/3/movie/top_rated?language=en-US&page=1 --> get best rated movies of all time (on page 1)
3. https://api.themoviedb.org/3/genre/movie/list?language=en --> get all genre-id tuples  
4. https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc --> get recent movies from best rated to worst rated


# Postman requests
1. Database endpoints:
    1. GET http://localhost:5152/api/tmdb/genres | fills Genre table with all genres available on TMDB
    2. GET http://localhost:5152/api/tmdb/movies | Add all popular movies (pages 1-21 TMDB) into my database while storing 10 actors and the director of each movie and creating the right many-to-many relationship pairs between each Entertainment-Genre and Entertainment-Cast.
    3. POST http://localhost:5152/api/user/register with the following body adds a new user to the database
    ```
    {
        "username": "Hugo0706",
        "firstName": "Hugo",
        "lastName": "Hakkenberg",
        "password": "SecurePassword123"
    }
    ``` 
    4. POST http://localhost:5152/api/user/login with the following body logs in a user
    ```
    {
        "username": "Hugo0706",
        "password": "SecurePassword123"
    }
    ```
    5. GET http://localhost:5152/api/entertainment/films | returns all ID-Title tuples of every film in the database 
    6. GET http://localhost:5152/api/entertainment/films/{id} | returns all data about a specific film
    7. GET http://localhost:5152/api/entertainment/castentertainment/{id} | returns (name, character) tuple of all cast members of specific film
    8. GET http://localhost:5152/api/entertainment/genresentertainment/{id} | returns all genre names of a specific film
    9. POST http://localhost:5152/api/user/userentertainment with the following body to add an entertainmentID-userID tuple
    ```
    {
        "userID": "1",
        "entertainmentID": "1"
    }
    ```
    
# Room for improvement
1. Inheritance relationship with User, Cast (Actor/Director)
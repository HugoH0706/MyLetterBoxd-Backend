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

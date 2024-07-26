using Microsoft.EntityFrameworkCore;
using MyLetterBoxd.Models;

namespace MyLetterBoxd.Database
{
    public class MyLetterBoxdContext : DbContext
    {
        public MyLetterBoxdContext(DbContextOptions<MyLetterBoxdContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<UserEntertainment> UserEntertainments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entertainment>()
                        .ToTable("Entertainments")
                        .HasDiscriminator<int>("EntertainmentType")
                        .HasValue<Film>(1)
                        .HasValue<Serie>(2);

            modelBuilder.Entity<UserEntertainment>()
                .HasKey(ue => new {ue.UserID, ue.EntertainmentID});
            
            modelBuilder.Entity<UserEntertainment>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserEntertainments)
                .HasForeignKey(ue => ue.UserID);

            modelBuilder.Entity<UserEntertainment>()
                .HasOne(ue => ue.Entertainment)
                .WithMany(e => e.UserEntertainments)
                .HasForeignKey(ue => ue.EntertainmentID);
            
             modelBuilder.Entity<User>().HasData(
                new User { ID = 1, Username = "JD", FirstName = "John", LastName = "Doe", Password = "password" },
                new User { ID = 2, Username = "JM", FirstName = "Jane", LastName = "Smith", Password = "password" }
            );

            modelBuilder.Entity<Film>().HasData(
                new Film { ID = 1, Title = "Inception", Genre = "Sci-Fi", Rating = Rating.FIVE, Directors = new List<string> { "Christopher Nolan" }, Actors = new List<string> { "Leonardo DiCaprio" } },
                new Film { ID = 2, Title = "The Matrix", Genre = "Sci-Fi", Rating = Rating.FIVE, Directors = new List<string> { "The Wachowskis" }, Actors = new List<string> { "Keanu Reeves" } }
            );

            modelBuilder.Entity<Serie>().HasData(
                new Serie { ID = 3, Title = "Breaking Bad", Genre = "Crime", Rating = Rating.FIVE, Seasons = 5, Directors = new List<string> { "Vince Gilligan" }, Actors = new List<string> { "Bryan Cranston" } },
                new Serie { ID = 4, Title = "Stranger Things", Genre = "Sci-Fi", Rating = Rating.FOUR, Seasons = 4, Directors = new List<string> { "The Duffer Brothers" }, Actors = new List<string> { "Winona Ryder" } }
            );

             modelBuilder.Entity<UserEntertainment>().HasData(
                new UserEntertainment { UserID = 1, EntertainmentID = 1},
                new UserEntertainment { UserID = 1, EntertainmentID = 2},
                new UserEntertainment { UserID = 2, EntertainmentID = 4}
            );
            
        }
    }
}

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
    }
}

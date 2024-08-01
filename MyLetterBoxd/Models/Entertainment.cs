using System.ComponentModel.DataAnnotations;

namespace MyLetterBoxd.Models
{
    public enum Rating 
    {
        ONE, TWO, THREE, FOUR, FIVE
    }
    public abstract class Entertainment
    {

        public int ID {get; set; }
        public required string Title {get; set; }
        public required string Description{get; set; }
        public required string ReleaseDate {get; set; }
        public required double Rating {get; set; }
        public List<Genre> Genre {get; set; } = new List<Genre>();
        public List<Cast> Actors {get; set; } = new List<Cast>();
        public List<Cast> Directors {get; set; } = new List<Cast>();
        public ICollection<UserEntertainment> UserEntertainments { get; set; } = new List<UserEntertainment>();
        public ICollection<GenreEntertainment> GenreEntertainments { get; set; } = new List<GenreEntertainment>();

    }
}
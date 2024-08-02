using System.ComponentModel.DataAnnotations;

namespace MyLetterBoxd.Models
{
    public abstract class Entertainment
    {
        public int ID {get; set; }
        public required string Title {get; set; }
        public required string Description{get; set; }
        public required string ReleaseDate {get; set; }
        public required double Rating {get; set; }
        public ICollection<UserEntertainment> UserEntertainments { get; set; } = new List<UserEntertainment>();
        public ICollection<GenreEntertainment> GenreEntertainments { get; set; } = new List<GenreEntertainment>();
        public ICollection<CastEntertainment> CastEntertainments { get; set; } = new List<CastEntertainment>();
    }
}
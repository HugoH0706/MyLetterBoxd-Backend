namespace MyLetterBoxd.Models
{
    public class Genre 
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<GenreEntertainment> GenreEntertainments { get; set; } = new List<GenreEntertainment>();
    }
}

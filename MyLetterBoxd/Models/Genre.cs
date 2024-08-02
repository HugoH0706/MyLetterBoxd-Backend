namespace MyLetterBoxd.Models
{
    public class Genre 
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public ICollection<GenreEntertainment> GenreEntertainments { get; set; } = new List<GenreEntertainment>();
    }
}

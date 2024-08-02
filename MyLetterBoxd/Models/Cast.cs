namespace MyLetterBoxd.Models
{
    public class Cast
    {
        public int ID {get; set; }
        public required string Name { get; set; }
        public string? Character { get; set; }
        public required string Role { get; set; }
        public ICollection<CastEntertainment> CastEntertainments { get; set; } = new List<CastEntertainment>();
    }
}

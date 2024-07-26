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
        public string Title {get; set; }
        public string Genre {get; set; }
        public List<string> Directors {get; set; } = new List<string>();
        public List<string> Actors {get; set; } = new List<string>();
        public Rating? Rating {get; set; }
        public ICollection<UserEntertainment> UserEntertainments { get; set; } = new List<UserEntertainment>();

    }
}
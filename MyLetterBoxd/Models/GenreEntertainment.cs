
namespace MyLetterBoxd.Models 
{
    public class GenreEntertainment
    {
        public int GenreID { get; set; }
        public Genre Genre { get; set; }

        public int EntertainmentID { get; set; }
        public Entertainment Entertainment { get; set; }
    }

}
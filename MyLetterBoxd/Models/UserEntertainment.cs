
namespace MyLetterBoxd.Models 
{
    public class UserEntertainment
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public int EntertainmentID { get; set; }
        public Entertainment Entertainment { get; set; }
    }

}
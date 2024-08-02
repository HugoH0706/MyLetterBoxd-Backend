namespace MyLetterBoxd.Models 
{
    public class CastEntertainment
    {
        public int CastID { get; set; }
        public Cast Cast { get; set; }

        public int EntertainmentID { get; set; }
        public Entertainment Entertainment { get; set; }
    }

}
using System.ComponentModel.DataAnnotations;

namespace MyLetterBoxd.DTO
{
    public class WatchlistRequest
    {
        [Required]
        public required int UserID { get; set; }
        
        [Required]
        public required int EntertainmentID { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace MyLetterBoxd.DTO
{
    public class EntertainmentRequest
    {
        [Required]
        public required int ID { get; set; }
        
        [Required]
        public required string Title { get; set; }
    }
}
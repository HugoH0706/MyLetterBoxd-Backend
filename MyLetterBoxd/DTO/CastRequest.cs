using System.ComponentModel.DataAnnotations;

namespace MyLetterBoxd.DTO
{
    public class CastRequest
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Character { get; set; }
    }
}
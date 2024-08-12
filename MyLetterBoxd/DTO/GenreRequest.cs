using System.ComponentModel.DataAnnotations;

namespace MyLetterBoxd.DTO
{
    public class GenreRequest
    {
        [Required]
        public required string[] Genres { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace MyLetterBoxd.DTO
{
    public class LoginRequest
    {
        [Required]
        [StringLength(50)]
        public required string Username { get; set; }
        
        [Required]
        public required string Password { get; set; }
    }
}
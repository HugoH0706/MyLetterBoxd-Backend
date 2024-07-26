using System.ComponentModel.DataAnnotations;

namespace MyLetterBoxd.DTO
{
    public class LoginRequest
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
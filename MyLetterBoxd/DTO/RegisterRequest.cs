using System.ComponentModel.DataAnnotations;

namespace MyLetterBoxd.DTO
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(50)]
        public required string Username { get; set; }
        
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }
        
        [Required]
        public required string Password { get; set; }
    }
}
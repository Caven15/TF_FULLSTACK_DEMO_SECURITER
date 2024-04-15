using System.ComponentModel.DataAnnotations;

namespace DemoSecurityAPI.Dto
{
    public class UserRegisterForm
    {
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Nom { get; set; } = String.Empty;
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Email { get; set; } = String.Empty;
        [Required]
        public DateTime DateNaissance { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string? Password { get; set; }
    }
}

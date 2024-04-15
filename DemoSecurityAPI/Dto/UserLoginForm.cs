using System.ComponentModel.DataAnnotations;

namespace DemoSecurityAPI.Dto
{
    public class UserLoginForm
    {
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}

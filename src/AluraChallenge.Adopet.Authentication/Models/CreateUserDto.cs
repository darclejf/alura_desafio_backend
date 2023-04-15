using System.ComponentModel.DataAnnotations;

namespace AluraChallenge.Adopet.Authentication.Models
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
        [Required]
        public string Role { get; set; }
    }
}

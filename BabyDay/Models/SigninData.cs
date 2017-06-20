using System.ComponentModel.DataAnnotations;

namespace BabyDay.Models
{
    public class SigninData
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
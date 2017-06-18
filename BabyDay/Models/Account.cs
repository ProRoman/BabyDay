namespace BabyDay.Models
{
    public class Account
    {
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
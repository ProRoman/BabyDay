﻿using System.ComponentModel.DataAnnotations;

namespace BabyDay.Models
{
    public class SignupData
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
    }
}
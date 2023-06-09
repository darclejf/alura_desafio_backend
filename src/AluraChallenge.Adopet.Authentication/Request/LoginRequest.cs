﻿using System.ComponentModel.DataAnnotations;

namespace AluraChallenge.Adopet.Authentication.Request
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace Currency.Model
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",ErrorMessage = "Password and cofirmation password do not mach.")]
        public string ConfirmPassword { get; set; }
    }
}

﻿namespace Git.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Git.Common;

    public class UserRegisterForm
    {
        [Required]
        [StringLength(Constants.LENGTH_20, MinimumLength = Constants.LENGTH_5, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Username { get; init; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; init; }

        [Required]
        [StringLength(Constants.LENGTH_20, MinimumLength = Constants.LENGTH_6, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Password { get; init; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password and password are not the same")]
        public string ConfirmPassword { get; init; }
    }
}

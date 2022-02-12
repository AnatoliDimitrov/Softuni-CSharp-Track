using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models.Users
{
    public class UserRegisterForm
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be berwenn {2} and {1} characters long")]
        public string Username { get; init; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; init; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Password { get; init; }

        [Compare("Password", ErrorMessage = "Confirm password and password are not the same")]
        public string ConfirmPassword { get; init; }
    }
}

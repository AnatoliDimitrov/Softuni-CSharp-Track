using System.ComponentModel.DataAnnotations;

using CarShop.Common.Constants;

namespace CarShop.ViewModels
{
    public class UserRegisterForm
    {
        [StringLength(Constants.LENGTH_20, MinimumLength = Constants.LENGTH_4, ErrorMessage = "{0} should be berwenn {2} and {1} characters long")]
        public string Username { get; init; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; init; }

        [StringLength(Constants.LENGTH_20, MinimumLength = Constants.LENGTH_6, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Password { get; init; }

        [Compare("Password", ErrorMessage = "Confirm password and password are not the same")]
        public string ConfirmPassword { get; init; }

        public string UserType { get; set; }
    }
}

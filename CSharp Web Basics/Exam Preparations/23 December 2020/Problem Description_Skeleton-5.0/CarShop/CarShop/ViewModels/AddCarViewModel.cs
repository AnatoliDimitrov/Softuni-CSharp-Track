namespace CarShop.ViewModels
{
    using CarShop.Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class AddCarViewModel
    {
        [Required]
        [StringLength(Constants.LENGTH_20, MinimumLength = Constants.LENGTH_5, ErrorMessage = "{0} should be berwenn {2} and {1} characters long")]
        public string Model { get; init; }

        [Required(ErrorMessage = "Valid year is rquired.")]
        public string Year { get; init; }

        [Required(ErrorMessage = "Url is rquired.")]
        public string Image { get; init; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}[0-9]{4}[A-Z]{2}$", ErrorMessage = "Invalid plate number.")]
        public string PlateNumber { get; init; }
    }
}

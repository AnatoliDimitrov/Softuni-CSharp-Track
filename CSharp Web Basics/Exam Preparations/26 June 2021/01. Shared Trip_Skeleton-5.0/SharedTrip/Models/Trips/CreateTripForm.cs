using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models.Trips
{
    public class CreateTripForm
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string StartPoint { get; init; }

        [Required(ErrorMessage = "{0} is required.")]
        public string EndPoint { get; init; }

        [Required(ErrorMessage = "{0} is required.")]
        public string DepartureTime { get; init; }

        [Required]
        public string Seats { get; init; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(80, ErrorMessage = "{0} should not be more then {1} characters long.")]
        public string Description { get; init; }

        public string ImagePath { get; init; }
    }
}

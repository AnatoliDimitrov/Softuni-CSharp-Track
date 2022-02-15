using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class AddIssueViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Descrption should be 5 characters minimum.")]
        public string Description { get; init; }

        [Required]
        public string CarId { get; init; }
    }
}

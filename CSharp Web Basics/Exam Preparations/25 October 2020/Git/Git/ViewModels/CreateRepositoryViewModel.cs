namespace Git.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Git.Common;

    public class CreateRepositoryViewModel
    {
        [Required]
        [StringLength(Constants.LENGTH_10, MinimumLength = Constants.LENGTH_3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Name { get; init; }

        public string RepositoryType { get; init; }
    }
}

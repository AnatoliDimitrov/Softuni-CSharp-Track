namespace Git.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Git.Common;

    public class AddCommitViewModel
    {
        public string RepositoryId { get; init; }

        [Required]
        [MinLength(Constants.LENGTH_5, ErrorMessage = "{0} should be {1} characters minimum.")]
        public string Description { get; init; }
    }
}

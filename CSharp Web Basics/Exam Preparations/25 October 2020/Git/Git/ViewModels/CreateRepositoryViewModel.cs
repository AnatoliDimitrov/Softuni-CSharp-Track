using Git.Common;
using System.ComponentModel.DataAnnotations;

namespace Git.ViewModels
{
    public class CreateRepositoryViewModel
    {
        [Required]
        [StringLength(Constants.LENGTH_10, MinimumLength = Constants.LENGTH_3, ErrorMessage = "{0} should be berwenn {2} and {1} characters long")]
        public string Name { get; init; }

        public string RepositoryType { get; init; }
    }
}

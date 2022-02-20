namespace FootballManager.ViewModels.Players
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FootballManager.Common;
    using FootballManager.Data.Models;

    public class AddPlayerViewModel
    {
        public AddPlayerViewModel()
        {
            this.UserPlayers = new HashSet<UserPlayer>();
        }

        [Required]
        [StringLength(Constants.LENGTH_80, MinimumLength = Constants.LENGTH_5, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string FullName { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(Constants.LENGTH_20, MinimumLength = Constants.LENGTH_5, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Position { get; init; }

        [Required]
        public string Speed { get; init; }

        [Required]
        public string Endurance { get; init; }

        [Required]
        [MaxLength(Constants.LENGTH_200, ErrorMessage = "{0} should be {1} characters maximum.")]
        public string Description { get; init; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}

namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FootballManager.Common;

    public class User
    {
        public User()
        {
            this.UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        [StringLength(Constants.LENGTH_100)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constants.LENGTH_20)]
        public string Username { get; init; }

        [Required]
        [StringLength(Constants.LENGTH_60)]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}

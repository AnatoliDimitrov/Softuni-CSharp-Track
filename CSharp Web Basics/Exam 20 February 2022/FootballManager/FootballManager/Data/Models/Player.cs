namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FootballManager.Common;

    public class Player
    {
        public Player()
        {
            this.UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        [StringLength(Constants.LENGTH_100)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constants.LENGTH_80)]
        public string FullName { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(Constants.LENGTH_20)]
        public string Position { get; init; }

        [Required]
        public byte Speed { get; init; }

        [Required]
        public byte Endurance { get; init; }

        [Required]
        [StringLength(Constants.LENGTH_200)]
        public string Description { get; init; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}

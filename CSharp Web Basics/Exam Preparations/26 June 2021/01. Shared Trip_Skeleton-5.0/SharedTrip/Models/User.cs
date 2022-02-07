namespace SharedTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.UserTrips = new HashSet<UserTrip>();
        }

        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}

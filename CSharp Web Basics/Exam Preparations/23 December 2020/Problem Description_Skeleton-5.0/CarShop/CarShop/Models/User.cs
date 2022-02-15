namespace CarShop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CarShop.Common.Constants;

    public class User
    {
        [Key]
        [StringLength(Constants.LENGTH_100)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constants.LENGTH_20)]
        public string Username { get; init; }

        [Required]
        [StringLength(Constants.LENGTH_100)]
        public string Email { get; init; }

        [Required]
        [StringLength (Constants.LENGTH_100)]
        public string Password { get; init; }

        public bool IsMechanic { get; set; }
    }
}

namespace CarShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarShop.Common.Constants;

    public class Car
    {
        public Car()
        {
            this.Issues = new HashSet<Issue>();
        }

        [Key]
        [StringLength(Constants.LENGTH_100)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constants.LENGTH_20)]
        public string Model { get; init; }

        [Required]
        public int Year { get; init; }

        [Required]
        public string PictureUrl { get; init; }

        [Required]
        public string PlateNumber { get; init; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}

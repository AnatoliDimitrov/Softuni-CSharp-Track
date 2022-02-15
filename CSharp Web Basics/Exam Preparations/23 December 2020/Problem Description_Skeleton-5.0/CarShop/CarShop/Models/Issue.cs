namespace CarShop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarShop.Common.Constants;

    public class Issue
    {
        [Key]
        [StringLength(Constants.LENGTH_100)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; init; }

        [Required]
        public bool IsFixed { get; set; }

        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }
        public Car Car { get; set; }
    }
}

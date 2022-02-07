namespace SMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Name { get; init; }

        [Required]
        public decimal Price { get; init; }

        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }
        public Cart Cart { get; set; }
    }
}

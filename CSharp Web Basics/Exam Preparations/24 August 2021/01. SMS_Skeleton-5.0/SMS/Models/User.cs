namespace SMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }

        [Required]
        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }
        [Required]
        public Cart Cart { get; set; }
    }
}

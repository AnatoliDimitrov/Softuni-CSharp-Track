namespace SMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Cart
    {
        public Cart()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

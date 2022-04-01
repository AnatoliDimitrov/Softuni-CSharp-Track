namespace Claudi.Infrastructure.Data.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ConfiguredProduct : BaseDeletableModel<string>
    {
        public ConfiguredProduct()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Extras = new HashSet<ProductExtra>();
        }

        [Required]
        [Range(1, 11)]
        public int TypeId { get; set; }
        public virtual ProductType Type { get; set; }

        [Required]
        [Range(1, 69)]
        public int ModelId { get; set; }
        public virtual ProductModel Model { get; set; }

        [Required]
        public string ColorId { get; set; }
        public virtual ProductColor Color { get; set; }

        [Required]
        [Range(1, 7000)]
        public decimal Width { get; set; }

        [Required]
        [Range(1, 4000)]
        public decimal Height { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        public decimal SquareMeters { get; set; }

        public virtual ICollection<ProductExtra> Extras { get; set; }

        [Required]
        public string UserId { get; set; }

        public decimal Price { get; set; }
    }
}

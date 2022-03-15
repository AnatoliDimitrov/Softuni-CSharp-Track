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
        public int TypeId { get; set; }
        public virtual ProductType Type { get; set; }

        [Required]
        public int ModelId { get; set; }
        public virtual ProductModel Model { get; set; }

        [Required]
        public string ColorId { get; set; }
        public virtual ProductColor Color { get; set; }

        [Required]
        public decimal Width { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal SquareMeters { get; set; }

        public virtual ICollection<ProductExtra> Extras { get; set; }

        [Required]
        public string UserId { get; set; }

        public decimal Price { get; set; }
    }
}

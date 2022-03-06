namespace Claudi.Web.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductColor : BaseDeletableModel<string>
    {
        public ProductColor()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Models = new HashSet<ProductModel>();
            this.ConfiguredProducts = new HashSet<ConfiguredProduct>();
        }

        [Required]
        [StringLength(20)]
        public string Number { get; init; }

        [Required]
        [StringLength(20)]
        public string Name { get; init; }

        [StringLength(20)]
        public string? Real { get; init; }

        public string? Group { get; init; }

        public string CssClass { get; set; }

        [Required]
        public string ImageUrl { get; init; }

        public virtual ICollection<ProductModel> Models { get; set; }

        public virtual ICollection<ConfiguredProduct> ConfiguredProducts { get; set; }
    }
}

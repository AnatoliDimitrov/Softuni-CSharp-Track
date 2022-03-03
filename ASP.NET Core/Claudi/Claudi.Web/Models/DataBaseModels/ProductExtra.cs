namespace Claudi.Web.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductExtra : BaseDeletableModel<int>
    {
        public ProductExtra()
        {
            this.Models = new HashSet<ProductModel>();
            this.ConfiguredProducts = new HashSet<ConfiguredProduct>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; init; }

        [StringLength(50)]
        public string? EnglishName { get; init; }

        public string Group { get; set; }

        public virtual ICollection<ProductModel> Models { get; set; }

        public virtual ICollection<ConfiguredProduct> ConfiguredProducts { get; set; }
    }
}

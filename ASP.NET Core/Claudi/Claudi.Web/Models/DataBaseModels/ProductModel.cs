namespace Claudi.Web.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductModel : BaseDeletableModel<int>
    {
        public ProductModel()
        {
            this.Colors = new HashSet<ProductColor>();
            this.Extras = new HashSet<ProductExtra>();
            this.Catalogues = new HashSet<ProductCatalogue>();
            this.ConfiguredProducts = new HashSet<ConfiguredProduct>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; init; }

        [Required]
        [StringLength(50)]
        public string EnglishName { get; init; }

        [Required]
        public int ProductTypeId { get; init; }
        public virtual ProductType Type { get; set; }

        public virtual ICollection<ProductColor> Colors { get; set; }

        public virtual ICollection<ProductExtra> Extras { get; set; }

        public virtual ICollection<ProductCatalogue> Catalogues { get; set; }

        public virtual ICollection<ConfiguredProduct> ConfiguredProducts { get; set; }
    }
}

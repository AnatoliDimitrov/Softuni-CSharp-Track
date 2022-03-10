namespace Claudi.Infrastructure.Data.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductType : BaseDeletableModel<int>
    {
        public ProductType()
        {

            this.Models = new HashSet<ProductModel>();
            this.Catalogues = new HashSet<ProductCatalogue>();
            this.ConfiguredProducts = new HashSet<ConfiguredProduct>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; init; }

        [Required]
        [StringLength(50)]
        public string NameShort { get; init; }

        [Required]
        [StringLength(50)]
        public string EnglishName { get; init; }

        [Required]
        [StringLength(50)]
        public string EnglishNameShort { get; init; }

        public virtual ICollection<ProductModel> Models { get; set; }

        public virtual ICollection<ProductCatalogue> Catalogues { get; set; }

        public virtual ICollection<ConfiguredProduct> ConfiguredProducts { get; set; }
    }
}

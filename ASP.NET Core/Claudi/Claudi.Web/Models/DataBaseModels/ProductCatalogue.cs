namespace Claudi.Web.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCatalogue : BaseDeletableModel<string>
    {
        public ProductCatalogue()
        {
            this.Id = Guid.NewGuid().ToString();
            Models = new HashSet<ProductModel>();
        }

        [Required]
        public int? TypeId { get; init; }
        public ProductType Type { get; set; }

        public virtual ICollection<ProductModel> Models { get; set; }

        public int RowNumber { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        public string Group { get; set; }
    }
}

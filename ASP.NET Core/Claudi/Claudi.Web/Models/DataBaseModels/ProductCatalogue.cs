namespace Claudi.Web.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCatalogue : BaseDeletableModel<string>
    {
        public ProductCatalogue()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public int? TypeId { get; init; }
        public ProductType Type { get; set; }

        [Required]
        public int ModelId { get; init; }
        public virtual ProductModel Model { get; set; }

        [Required]
        public string ImageUrl { get; init; }
    }
}

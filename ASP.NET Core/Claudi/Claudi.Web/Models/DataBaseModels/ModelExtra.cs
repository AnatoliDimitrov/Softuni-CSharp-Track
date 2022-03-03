namespace Claudi.Web.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ModelExtra
    {
        [Required]
        public int ModelId { get; init; }
        public virtual ProductModel Model { get; set; }

        [Required]
        public int ExtralId { get; init; }
        public virtual ProductExtra Extra { get; set; }
    }
}

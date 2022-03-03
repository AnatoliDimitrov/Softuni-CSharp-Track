namespace Claudi.Web.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ModelColor
    {
        [Required]
        public int ModelId { get; init; }
        public virtual ProductModel Model { get; set; }

        [Required]
        public string ColorId { get; set; }
        public virtual ProductColor Color { get; set; }
    }
}

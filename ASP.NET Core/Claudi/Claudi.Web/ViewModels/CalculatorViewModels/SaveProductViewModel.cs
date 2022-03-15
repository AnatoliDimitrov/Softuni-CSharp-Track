namespace Claudi.Web.ViewModels.CalculatorViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class SaveProductViewModel
    {
        public SaveProductViewModel()
        {
            this.Extras = new List<string>();
        }

        [Required]
        public string TypeId { get; set; }

        [Required]
        public string ModelId { get; set; }

        [Required]
        public string ColorId { get; set; }

        [Required]
        public string Width { get; set; }

        [Required]
        public string Height { get; set; }

        [Required]
        public string Quantity { get; set; }

        [Required]
        public string SquareMeters { get; set; }

        public virtual ICollection<string> Extras { get; set; }

        [Required]
        public string UserId { get; set; }

        public string Price { get; set; }
    }
}

namespace Claudi.Core.ViewModels.CalculatorViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class SaveProductViewModel
    {
        public SaveProductViewModel()
        {
            this.Extras = new List<string>();
        }

        [Required]
        public string Type { get; init; }

        [Required]
        public string ModelId { get; init; }

        [Required]
        public string ColorId { get; init; }

        [Required]
        public string Width { get; init; }

        [Required]
        public string Height { get; init; }

        [Required]
        public string Quantity { get; init; }

        [Required]
        public string SquareMeters { get; init; }

        public virtual ICollection<string> Extras { get; set; }

        public string Price { get; init; }
    }
}

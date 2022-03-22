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
        public string Type { get; set; }

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

        public string Price { get; set; }
    }
}

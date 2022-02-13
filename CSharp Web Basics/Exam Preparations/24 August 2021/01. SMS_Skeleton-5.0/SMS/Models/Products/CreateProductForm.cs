namespace SMS.Models.Products
{
    using SMS.Common;
    using System.ComponentModel.DataAnnotations;

    public class CreateProductForm
    {
        [Required]
        [StringLength(Constants.LENGTH_20, MinimumLength = Constants.LENGTH_4, ErrorMessage = "{0} should be berwenn {2} and {1} characters long")]
        public string Name { get; init; }

        [Required]
        public string Price { get; init; }
    }
}

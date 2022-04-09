namespace Claudi.Core.ViewModels.MyProductsViewModels
{
    public class MyProductViewModel
    {
        public string Id { get; init; }

        public string Type { get; init; }
        
        public string Model { get; init; }
        
        public string Color { get; init; }

        public string ColorGroup { get; init; }

        public decimal Width { get; init; }

        public decimal Height { get; init; }
        
        public decimal SquareMeters { get; init; }

        public int Quantity { get; init; }

        public virtual ICollection<string> Extras { get; set; }

        public decimal Price { get; init; }
    }
}

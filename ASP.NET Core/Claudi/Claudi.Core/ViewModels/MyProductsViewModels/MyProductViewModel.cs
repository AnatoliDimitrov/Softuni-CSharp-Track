namespace Claudi.Core.ViewModels.MyProductsViewModels
{
    public class MyProductViewModel
    {
        public string Id { get; set; }

        public string Type { get; set; }
        
        public string Model { get; set; }
        
        public string Color { get; set; }

        public string ColorGroup { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }
        
        public decimal SquareMeters { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<string> Extras { get; set; }

        public decimal Price { get; set; }
    }
}

namespace Claudi.Core.ViewModels.MyProductsViewModels
{
    public class MyProductViewModel
    {
        public string Id { get; set; }

        public int TypeId { get; set; }
        
        public string Model { get; set; }
        
        public string Color { get; set; }
        
        public decimal Width { get; set; }

        public decimal Height { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal SquareMeters { get; set; }

        public virtual ICollection<int> Extras { get; set; }
    }
}

namespace Claudi.Core.ViewModels.CataloguesViewModels
{
    public class CatalogueViewModel
    {
        public int? TypeId { get; init; }

        public string CssClass { get; set; }

        public int Number { get; init; }
        
        public string ImageUrl { get; init; }

        public string Group { get; set; }
    }
}

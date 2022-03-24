namespace Claudi.Core.ViewModels.CataloguesViewModels
{
    public class CataloguesViewModel
    {
        public string Type { get; set; }

        public IEnumerable<CataloguesGroupsViewModel> Groups { get; set; }

        public IEnumerable<CatalogueViewModel> Catalogues { get; set; }
    }
}

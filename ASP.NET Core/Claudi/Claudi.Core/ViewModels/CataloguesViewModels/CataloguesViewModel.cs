using System.Security.AccessControl;

namespace Claudi.Core.ViewModels.CataloguesViewModels
{
    public class CataloguesViewModel
    {
        public string Type { get; set; }

        public bool IsSuccessful { get; set; } = false;

        public IEnumerable<CataloguesGroupsViewModel> Groups { get; set; }

        public IEnumerable<CatalogueViewModel> Catalogues { get; set; }
    }
}

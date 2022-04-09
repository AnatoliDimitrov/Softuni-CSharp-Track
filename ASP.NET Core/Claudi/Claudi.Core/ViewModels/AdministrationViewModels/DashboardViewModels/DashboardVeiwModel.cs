namespace Claudi.Core.ViewModels.AdministrationViewModels.DashboardViewModels
{
    public class DashboardVeiwModel
    {
        public bool Created { get; set; }

        public int AccountsCount { get; init; }

        public int AdministratorsCount { get; init; }

        public int SamplesCount { get; init; }

        public int CataloguesCount { get; init; }

        public int GalleryCount { get; init; }
    }
}

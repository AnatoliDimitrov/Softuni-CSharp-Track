namespace Claudi.Core.Administration.DashboardServices
{
    using ViewModels.AdministrationViewModels.DashboardViewModels;

    public interface IDashboardService
    {
        Task<DashboardVeiwModel> GetDashboardInfo();
    }
}

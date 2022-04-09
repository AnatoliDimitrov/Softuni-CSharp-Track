namespace Claudi.Core.Administration.AccountsServices
{
    using ViewModels.AdministrationViewModels.AccountsViewModels;

    public interface IAccountsService
    {
        Task<IndexUsersViewModel> GetDashboardInfoAsync();

        Task<bool> MakeUserAdministratorAsync(string id);

        Task<bool> RemoveUserAdministratorRoleAsync(string id);

        Task<bool> DeleteUserAsync(string id);

        Task<bool> ConfirmUserEmailAsync(string id);
    }
}

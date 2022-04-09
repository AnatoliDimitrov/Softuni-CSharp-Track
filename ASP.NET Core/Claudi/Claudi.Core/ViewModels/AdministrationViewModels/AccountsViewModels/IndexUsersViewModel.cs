namespace Claudi.Core.ViewModels.AdministrationViewModels.AccountsViewModels
{
    public class IndexUsersViewModel
    {
        public string? Message { get; set; }

        public bool Created { get; set; } = true;

        public List<UsersViewModel> Users { get; init; }
    }
}

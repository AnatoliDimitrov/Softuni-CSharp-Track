namespace Claudi.Core.ViewModels.AdministrationViewModels.AccountsViewModels
{
    public class UsersViewModel
    {
        public string Id { get; init; }

        public string Email { get; init; }

        public bool IsAdmin { get; init; }

        public bool IsEmailConfirmed { get; init; }
    }
}

namespace Claudi.Core.ViewModels.AdministrationViewModels.AccountsViewModels
{
    public class UsersViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsEmailConfirmed { get; set; }
    }
}

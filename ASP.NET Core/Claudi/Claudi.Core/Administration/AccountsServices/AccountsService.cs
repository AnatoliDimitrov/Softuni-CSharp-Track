namespace Claudi.Core.Administration.AccountsServices
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using ViewModels.AdministrationViewModels.AccountsViewModels;

    public class AccountsService : IAccountsService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task<List<UsersViewModel>> GetDashboardInfoAsync()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Administrator");

            var users = await _userManager.Users
                .Where(u => u.Email != "apdimitrov@yahoo.com")
                .Select(u => new UsersViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    IsAdmin = admins.Contains(u),
                    IsEmailConfirmed = u.EmailConfirmed,
                })
                .OrderBy(u => u.IsAdmin == false)
                .ThenBy(u => u.IsEmailConfirmed == false)
                .ThenBy(u => u.Email)
                .ToListAsync();

            return users;
        }

        public async Task<bool> MakeUserAdministratorAsync(string id)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            var result = await _userManager.AddToRoleAsync(user, "Administrator");

            return result.Succeeded;
        }

        public async Task<bool> RemoveUserAdministratorRoleAsync(string id)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            var result = await _userManager.RemoveFromRoleAsync(user, "Administrator");

            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            var result = await _userManager.DeleteAsync(user);

            return result.Succeeded;
        }

        public async Task<bool> ConfirmUserEmailAsync(string id)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var result = await _userManager.ConfirmEmailAsync(user, token);

            return result.Succeeded;
        }
    }
}

using Claudi.Core.ViewModels.AdministrationViewModels.AccountsViewModels;

namespace Claudi.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Claudi.Core.Administration.AccountsServices;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class AccountsController : Controller
    {
        private readonly IAccountsService _service;

        public AccountsController(IAccountsService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _service.GetDashboardInfoAsync();

            var model = new IndexUsersViewModel()
            {
                Users = users,
            };

            return this.View(model);
        }

        public async Task<IActionResult> MakeAccountAdmin(string id)
        {
            var result = await _service.MakeUserAdministratorAsync(id);

            return this.RedirectToAction("Accounts", "Administration");
        }

        public async Task<IActionResult> RemoveAccountAdmin(string id)
        {
            var result = await _service.RemoveUserAdministratorRoleAsync(id);

            return this.RedirectToAction("Accounts", "Administration");
        }

        public async Task<IActionResult> DeleteAccount(string id)
        {
            await _service.DeleteUserAsync(id);

            return this.RedirectToAction("Accounts", "Administration");
        }

        public async Task<IActionResult> ConfirmEmail(string id)
        {

            await _service.ConfirmUserEmailAsync(id);

            return this.RedirectToAction("Accounts", "Administration");
        }
    }
}

using Claudi.Infrastructure.Common;

namespace Claudi.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Core.Administration.AccountsServices;
    using Core.ViewModels.AdministrationViewModels.AccountsViewModels;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class AccountsController : Controller
    {
        private readonly IAccountsService _service;

        public AccountsController(IAccountsService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index(string message)
        {
            var model = await _service.GetDashboardInfoAsync();

            model.Message = message;

            return this.View(model);
        }

        public async Task<IActionResult> MakeAccountAdmin(string id)
        {
            var result = await _service.MakeUserAdministratorAsync(id);

            var message = result ? Constants.SUCCESS : Constants.FAILD;

            return this.RedirectToAction("Accounts", "Administration", new { message = message });
        }

        public async Task<IActionResult> RemoveAccountAdmin(string id)
        {
            var result = await _service.RemoveUserAdministratorRoleAsync(id);

            var message = result ? Constants.SUCCESS : Constants.FAILD;

            return this.RedirectToAction("Accounts", "Administration", new { message = message });
        }

        public async Task<IActionResult> DeleteAccount(string id)
        {
            var result = await _service.DeleteUserAsync(id);

            var message = result ? Constants.SUCCESS : Constants.FAILD;

            return this.RedirectToAction("Accounts", "Administration", new { message = message });
        }

        public async Task<IActionResult> ConfirmEmail(string id)
        {

            var result = await _service.ConfirmUserEmailAsync(id);

            var message = result ? Constants.SUCCESS : Constants.FAILD;

            return this.RedirectToAction("Accounts", "Administration", new { message = message });
        }
    }
}

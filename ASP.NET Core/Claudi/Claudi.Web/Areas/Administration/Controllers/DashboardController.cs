namespace Claudi.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Claudi.Core.Administration.DashboardServices;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _service; 

        public DashboardController(IDashboardService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetDashboardInfo();

            return this.View(model);
        }
    }
}

namespace Claudi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Claudi.Infrastructure.Data;
    using Claudi.Core.ViewModels.ColorsViewModels;
    using Claudi.Core.ColorsServices;

    public class ColorsController : Controller
    {
        private readonly IColorsService _service;
        public ColorsController(IColorsService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllTypesAsync();

            return View(model);
        }

        public async Task<IActionResult> Horizontal()
        {

            return View("Multiple", await GetColorsAsync("horizontal"));
        }

        public async Task<IActionResult> Vertical()
        {
            return View("Multiple", await GetColorsAsync("vertical"));
        }

        public async Task<IActionResult> Wooden()
        {
            return View("Multiple", await GetColorsAsync("wooden"));
        }

        public async Task<IActionResult> Roller()
        {
            return View("Multiple", await GetColorsAsync("roller"));
        }

        public async Task<IActionResult> Roman()
        {
            return View("Multiple", await GetColorsAsync("roman"));
        }

        public async Task<IActionResult> Pleat()
        {
            return View("Multiple", await GetColorsAsync("pleats"));
        }

        public async Task<IActionResult> Bamboo()
        {
            return View("Multiple", await GetColorsAsync("bamboo"));
        }

        public async Task<IActionResult> ExternalRoller()
        {
            return View("Multiple", await GetColorsAsync("externalRoller"));
        }

        public async Task<IActionResult> ExternalVenetian()
        {
            return View("Multiple", await GetColorsAsync("external"));
        }

        public async Task<IActionResult> Tents()
        {
            return View("Multiple", await GetColorsAsync("awning"));
        }

        public async Task<IActionResult> Nets()
        {
            return View("Multiple", await GetColorsAsync("nets"));
        }

        private async Task<ColorsViewModel> GetColorsAsync(string type)
        {
            var colors = await _service.GetAllColorsAsync(type);

            var groups = await _service.GetAllGroupsAsync(type);

            return new ColorsViewModel()
            {
                Type = "Хоризонтални Щори",
                Groups = groups,
                Colors = colors,
            };
        }
    }
}

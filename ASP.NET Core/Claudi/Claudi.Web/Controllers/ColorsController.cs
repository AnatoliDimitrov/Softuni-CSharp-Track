using Claudi.Core.ViewModels.CommonViewModels;
using Claudi.Infrastructure.Common;

namespace Claudi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Core.ViewModels.ColorsViewModels;
    using Core.ColorsServices;

    public class ColorsController : Controller
    {
        private readonly IColorsService _service;
        public ColorsController(IColorsService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TypeViewModel> model;
            try
            {
                model = await _service.GetAllTypesAsync();
            }
            catch (Exception )
            {
                return RedirectToAction("Error", "Home");
            }
            return View(model.ToList());
        }

        public async Task<IActionResult> Horizontal()
        {

            return View("Multiple", await GetColorsAsync("horizontal", "Хоризонтални Щори"));
        }

        public async Task<IActionResult> Vertical()
        {
            var models = new[] { "89mm", "127mm", "al" };

            var colors = await _service.GetAllVerticalColorsAsync();

            colors = colors.ToList()
                .OrderBy(c => Array.IndexOf(models, c.Name))
                .ThenBy(c => c.Group);

            var groups = await _service.GetAllVerticalGroupsAsync();

            groups = groups.ToList()
            .OrderBy(c => Array.IndexOf(models, c.Group));

            var model = new ColorsViewModel()
            {
                Type = "Вертикални Щори",
                Groups = groups,
                Colors = colors,
            };

            return View("Multiple", model);
        }

        public async Task<IActionResult> Wooden()
        {
            return View("Multiple", await GetColorsAsync("wooden", "Дървени Щори"));
        }

        public async Task<IActionResult> Roller()
        {
            return View("Multiple", await GetColorsAsync("roller", "Руло и Ден и Нощ Щори"));
        }

        public async Task<IActionResult> Roman()
        {
            return View("Multiple", await GetColorsAsync("roman", "Римски Щори"));
        }

        public async Task<IActionResult> Pleat()
        {
            return View("Multiple", await GetColorsAsync("pleats", "Плисе Щори"));
        }

        public async Task<IActionResult> Bamboo()
        {
            return View("Multiple", await GetColorsAsync("bamboo", "Бамбукови Щори"));
        }

        public async Task<IActionResult> ExternalRoller()
        {
            return View("Multiple", await GetColorsAsync("externalRoller", "Външни Ролетни Щори"));
        }

        public async Task<IActionResult> ExternalVenetian()
        {
            return View("Multiple", await GetColorsAsync("external", "Външни Хоризонтални Щори"));
        }

        public async Task<IActionResult> Tents()
        {
            return View("Multiple", await GetColorsAsync("awning", "Сенници"));
        }

        public async Task<IActionResult> Nets()
        {
            return View("Multiple", await GetColorsAsync("nets", "Мрежи Против Насекоми"));
        }

        private async Task<ColorsViewModel> GetColorsAsync(string type, string name)
        {
            IEnumerable<ColorViewModel> colors = null;
            IEnumerable<ColorsGroupsViewModel> groups = null;
            try
            {
                //throw new ArgumentException();
                colors = await _service.GetAllColorsAsync(type);

                groups = await _service.GetAllGroupsAsync(type);
            }
            catch (Exception)
            {
                return new ColorsViewModel()
                {
                    Type = Constants.FAILD,
                    Groups = groups,
                    Colors = colors,
                };
            }

            return new ColorsViewModel()
            {
                Type = name,
                Groups = groups,
                Colors = colors,
            };
        }
    }
}

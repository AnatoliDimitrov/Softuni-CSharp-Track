namespace Claudi.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using Core.CataloguesServices;
    using Core.ViewModels.CataloguesViewModels;

    public class CataloguesController : Controller
    {
        private readonly ICataloguesService _service;
        public CataloguesController(ICataloguesService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllTypesAsync();
            
            if (model.Count() == 0)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(model.ToList());
        }

        public async Task<IActionResult> Horizontal()
        {
            return View("Multiple", await GetCataloguesAsync(1, "Хоризонтални Щори"));
        }

        public async Task<IActionResult> Vertical()
        {
            return View("Multiple", await GetCataloguesAsync(2, "Вертикални Щори"));
        }

        public async Task<IActionResult> Wooden()
        {
            return View("Multiple", await GetCataloguesAsync(3, "Дървени Щори"));
        }

        public async Task<IActionResult> Roller()
        {
            return View("Multiple", await GetCataloguesAsync(4, "Руло Щори"));
        }

        public async Task<IActionResult> Roman()
        {
            return View("Multiple", await GetCataloguesAsync(5, "Римски Щори"));
        }

        public async Task<IActionResult> Bamboo()
        {
            return View("Multiple", await GetCataloguesAsync(6, "Бамбукови Щори"));
        }

        public async Task<IActionResult> Pleat()
        {
            return View("Multiple", await GetCataloguesAsync(7, "Плисе Щори"));
        }

        public async Task<IActionResult> ExternalRoller()
        {
            return View("Multiple", await GetCataloguesAsync(8, "Външни ролетни Щори"));
        }

        public async Task<IActionResult> ExternalVenetian()
        {
            return View("Multiple", await GetCataloguesAsync(9, "Външни Хоризонтални Щори"));
        }

        public async Task<IActionResult> Tents()
        {
            return View("Multiple", await GetCataloguesAsync(10, "Сенници"));
        }

        public async Task<IActionResult> Nets()
        {
            return View("Multiple", await GetCataloguesAsync(11, "Мрежи Против Насекоми"));
        }

        private async Task<CataloguesViewModel> GetCataloguesAsync(int typeId, string name)
        {
            var model = new CataloguesViewModel();
            IEnumerable<CatalogueViewModel> catalogues = null;
            IEnumerable<CataloguesGroupsViewModel> groups = null;
            try
            {
                //throw new ArgumentException(); 
                catalogues = await _service.GetAllCatalaguesAsync(typeId);

                groups = await _service.GetAllGroupsAsync(typeId);

                model = new CataloguesViewModel()
                {
                    Type = name,
                    IsSuccessful = true,
                    Groups = groups,
                    Catalogues = catalogues,
                };
            }
            catch (Exception)
            {
                model.IsSuccessful = false;
            }

            return model;
        }
    }
}

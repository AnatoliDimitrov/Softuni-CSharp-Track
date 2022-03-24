using Claudi.Core.CataloguesServices;
using Claudi.Core.ViewModels.CataloguesViewModels;
using Claudi.Core.ViewModels.ColorsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Claudi.Web.Controllers
{
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

            return View(model.ToList());
        }

        public async Task<IActionResult> Horizontal()
        {
            return View("Multiple", await GetCataloguesAsync(1, "Хоризонтални Щори"));
        }

        public async Task<IActionResult> Vertical()
        {
            return View("Multiple", await GetCataloguesAsync(1, "Хоризонтални Щори"));
        }

        private async Task<CataloguesViewModel> GetCataloguesAsync(int typeId, string name)
        {
            var catalogues = await _service.GetAllCatalaguesAsync(typeId);

            var groups = await _service.GetAllGroupsAsync(typeId);

            return new CataloguesViewModel()
            {
                Type = name,
                Groups = groups,
                Catalogues = catalogues,
            };
        }
    }
}

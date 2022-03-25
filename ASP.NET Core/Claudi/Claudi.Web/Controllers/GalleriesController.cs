using Claudi.Core.GalleriesServices;
using Claudi.Core.ViewModels.GalleriesViewModels;

namespace Claudi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class GalleriesController : Controller
    {
        private readonly IGalleriesService _service;

        public GalleriesController(IGalleriesService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await GetAllPicturesAsync("Галерия");

            return View(model);
        }

        private async Task<GalleriesViewModel> GetAllPicturesAsync(string name)
        {
            var pictures = await _service.GetAllPicturesAsync();

            var groups = await _service.GetAllGroupsAsync();

            return new GalleriesViewModel()
            {
                Type = name,
                Groups = groups,
                Pictures = pictures,
            };
        }
    }
}

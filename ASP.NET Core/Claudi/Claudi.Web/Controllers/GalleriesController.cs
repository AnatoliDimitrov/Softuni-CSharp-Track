using Claudi.Infrastructure.Common;

namespace Claudi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Core.GalleriesServices;
    using Core.ViewModels.GalleriesViewModels;

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
            IEnumerable<GalleryPictureViewModel> pictures = null;
            IEnumerable<GalleresGroupsViewModel> groups = null;
            try
            {
                //throw new ArgumentException();
                pictures = await _service.GetAllPicturesAsync();

                groups = await _service.GetAllGroupsAsync();
            }
            catch (Exception)
            {
                return new GalleriesViewModel()
                {
                    Type = Constants.FAILD,
                    Groups = groups,
                    Pictures = pictures,
                };
            }

            return new GalleriesViewModel()
            {
                Type = name,
                Groups = groups,
                Pictures = pictures,
            };
        }
    }
}

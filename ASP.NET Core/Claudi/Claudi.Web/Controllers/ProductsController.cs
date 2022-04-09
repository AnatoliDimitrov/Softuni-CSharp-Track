namespace Claudi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Core.ProductsServices;

    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        public ProductsController(IProductsService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _service.GetAllTypesAsync();

                return View(model.ToList());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Horizontal()
        {
            return View();
        }

        public async Task<IActionResult> Vertical()
        {
            return View();
        }
        public async Task<IActionResult> Wooden()
        {
            return View();
        }
        public async Task<IActionResult> Roller()
        {
            return View();
        }
        public async Task<IActionResult> Roman()
        {
            return View();
        }
        public async Task<IActionResult> Pleat()
        {
            return View();
        }
        public async Task<IActionResult> ExternalRoller()
        {
            return View();
        }
        public async Task<IActionResult> ExternalVenetian()
        {
            return View();
        }
        public async Task<IActionResult> Bamboo()
        {
            return View();
        }
        public async Task<IActionResult> Tents()
        {
            return View();
        }
        public async Task<IActionResult> Nets()
        {
            return View();
        }
    }
}

namespace Claudi.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Core.MyProductsServices;
    using Core.ViewModels.MyProductsViewModels;

    [Authorize]
    public class MyProductsController : Controller
    {
        private readonly IMyProductsService _service;

        public MyProductsController(IMyProductsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(DeleteViewModel model)
        {
            try
            {
                await _service.DeleteProduct(model.Id);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

            return this.View();
        }
        
        public async Task<List<MyProductViewModel>> GetMyProducts()
        {
            List<MyProductViewModel> products = null;

            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                products = await _service.GetProductsAsync(userId);
            }
            catch (Exception)
            {
                return new List<MyProductViewModel>();
            }

            return products;
        }
    }
}

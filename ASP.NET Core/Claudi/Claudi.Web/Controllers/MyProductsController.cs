using Claudi.Core.MyProductsServices;
using Claudi.Core.ViewModels.MyProductsViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Claudi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

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
        [Authorize]
        public async Task<IActionResult> Index(DeleteViewModel model)
        {
            await _service.DeleteProduct(model.Id);

            return this.View();
        }

        [Authorize]
        public async Task<List<MyProductViewModel>> GetMyProducts()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var products = await _service.GetProductsAsync(userId);

            return products;
        }
    }
}

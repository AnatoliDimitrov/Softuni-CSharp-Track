namespace Claudi.Web.Controllers
{
    using System.Security.Claims;
    using System.Text.Json;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.Caching.Distributed;

    using Core.ClaculatorsServices;
    using Core.ViewModels.CalculatorViewModels;

    using Infrastructure.Common;

    public class CalculatorsController : Controller
    {
        private readonly ISiteCalculatorService _service;
        private readonly IDistributedCache _cache;

        public CalculatorsController(ISiteCalculatorService service,
            IDistributedCache cache)
        {
            this._service = service;
            this._cache = cache;
        }

        public async Task<IActionResult> Index(string saved)
        {
            var cachedTypes = await _cache.GetStringAsync("productTypes");

            if (cachedTypes == null)
            {
                List<TypeViewModel> result = null;

                try
                {
                    result = await _service.GetProductTypesAsync();
                }
                catch (Exception)
                {
                    ReturnError();
                }

                cachedTypes = JsonSerializer.Serialize(result);

                DistributedCacheEntryOptions cacheOptions = new DistributedCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromHours(1),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(3),
                };

                await _cache.SetStringAsync("productTypes", cachedTypes);
            }

            var types = JsonSerializer.Deserialize<List<TypeViewModel>>(cachedTypes);

            var model = new IndexViewModel()
            {
                Products = types,
                Saved = saved
            };

            return this.View(model);
        }

        public async Task<List<ModelViewModel>> ProductModels(int id)
        {
            try
            {
                return await _service.GetProductModelsAsync(id);
            }
            catch (Exception)
            {
                ReturnError();
            }

            return new List<ModelViewModel>();
        }

        public bool IsLoggedIn()
        {
            try
            {
                return User.Identity.IsAuthenticated;
            }
            catch (Exception)
            {
                ReturnError();
            }

            return false;
        }

        public async Task<List<ColorViewModel>> ProductColors(int id)
        {
            try
            {
                return await _service.GetProductColors(id);
            }
            catch (Exception)
            {
                ReturnError();
            }

            return new List<ColorViewModel>();
        }

        public async Task<List<ExtraViewModel>> ProductExtras(int id)
        {
            try
            {
                return await _service.GetProductExtras(id);
            }
            catch (Exception)
            {
                ReturnError();
            }

            return new List<ExtraViewModel>();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(SaveProductViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var saved = false;

            if (!ModelState.IsValid)
            {
                return await this.Index(Constants.FAILD);
            }

            try
            {
                saved = await _service.SaveProduct(model, userId);
            }
            catch (Exception)
            {
                return await this.Index(Constants.FAILD);
            }

            if (!saved)
            {
                return await this.Index(Constants.FAILD);
            }

            return await this.Index(Constants.SUCCESS);
        }

        private IActionResult ReturnError()
        {
            return RedirectToAction("Error", "Home");
        }
    }
}

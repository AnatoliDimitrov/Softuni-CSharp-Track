using Microsoft.Extensions.Caching.Distributed;

namespace Claudi.Web.Controllers
{
    using System.Security.Claims;
    using System.Text.Json;

    using Microsoft.AspNetCore.Mvc;

    using Microsoft.AspNetCore.Authorization;

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
                var result = await _service.GetProductTypesAsync();

                cachedTypes = JsonSerializer.Serialize(result);

                DistributedCacheEntryOptions cacheOptions = new DistributedCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromHours(1),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1),
                };

                await _cache.SetStringAsync("productTypes", cachedTypes);
            }

            //var types = await _service.GetProductTypesAsync();
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
            var cachedData = await _cache.GetStringAsync("productModels");

            if (cachedData == null)
            {
                
            }

            return await _service.GetProductModelsAsync(id);
        }

        public bool IsLoggedIn()
        {
            return User.Identity.IsAuthenticated;
        }

        public async Task<List<ColorViewModel>> ProductColors(int id)
        {
            return await _service.GetProductColors(id);
        }

        public async Task<List<ExtraViewModel>> ProductExtras(int id)
        {
            return await _service.GetProductExtras(id);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(SaveProductViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return this.ValidationProblem(userId);
            }

            var saved = await _service.SaveProduct(model, userId);

            if (!saved)
            {
                return await this.Index(Constants.FAILD);
            }

            return await this.Index(Constants.SUCCESS);
        }
    }
}

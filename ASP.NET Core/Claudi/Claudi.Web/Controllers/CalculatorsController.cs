﻿namespace Claudi.Web.Controllers
{
    using Claudi.Core.ClaculatorsServices;
    using Claudi.Core.ViewModels.CalculatorViewModels;

    using Claudi.Infrastructure.Common;
    using Claudi.Infrastructure.Data;

    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class CalculatorsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ISiteCalculatorService service;

        public CalculatorsController(ISiteCalculatorService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Index(string saved)
        {
            var types = await service.GetProductTypesAsync();

            var model = new IndexViewModel()
            {
                Products = types,
                Saved = saved
            };

            return this.View(model);
        }

        public async Task<List<ModelViewModel>> ProductModels(int id)
        {
            return await service.GetProductModelsAsync(id);
        }

        public bool IsLoggedIn()
        {
            return User.Identity.IsAuthenticated;
        }

        public async Task<List<ColorViewModel>> ProductColors(int id)
        {
            return await service.GetProductColors(id);
        }

        public async Task<List<ExtraViewModel>> ProductExtras(int id)
        {
            return await service.GetProductExtras(id);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SaveProductViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return this.ValidationProblem(userId);
            }

            var saved = await service.SaveProduct(model, userId);

            if (!saved)
            {
                return this.ValidationProblem(userId);
            }

            return await this.Index(Constants.SUCCESS);
        }
    }
}

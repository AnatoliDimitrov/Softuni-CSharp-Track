namespace Claudi.Web.Controllers
{
    using Claudi.Infrastructure.Data;
    using Claudi.Web.ViewModels.CalculatorViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class CalculatorsController : Controller
    {
        private readonly ApplicationDbContext context;

        public CalculatorsController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            List<TypeViewModel> products = context
                .ProductTypes
                .ToList()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ShortName = t.NameShort,
                })
                .ToList();

            return this.View(products);
        }

        public async Task<List<ModelViewModel>> ProductModels(int Id)
        {
            return await context
                .ProductModels
                .Where(p => p.OnCalculator == true && p.ProductTypeId == Id)
                .Select(p => new ModelViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                })
                .ToListAsync();
        }

        public async Task<List<ColorViewModel>> ProductColors(int Id)
        {
            var model = await context
                .ProductModels
                .FirstOrDefaultAsync(p => p.Id == Id);

            return await context
                .ProductColors
                .Where(c => c.Models.Contains(model))
                .Select(p => new ColorViewModel()
                 {
                     Id = p.Id,
                     Number = p.Number,
                     Group = p.Group,
                     Url = p.ImageUrl,
                 })
                .ToListAsync();
        }
    }
}

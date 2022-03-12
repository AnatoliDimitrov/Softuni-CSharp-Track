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
            var externalRollers = new int[] { 44, 45, 46 };
            var model = await context
                .ProductModels
                .FirstOrDefaultAsync(p => p.Id == Id);

            var filter = Id switch
            {
                var x when (x >= 1 && x <= 9) => "25mm",
                13 => "25mm",
                14 => "50mm",
                _ => null
            };

            var colors = await context
                .ProductColors
                .Where(c => c.Models.Contains(model))
                .Select(p => new ColorViewModel()
                {
                    Id = p.Id,
                    Number = p.Number,
                    Group = p.Group,
                    Url = p.ImageUrl,
                })
                .OrderBy(c => c.Group)
                .ThenBy(c => c.Number)
                .ToListAsync();

            if (filter != null)
            {
                colors = colors
                    .Where(c => c.Group == filter).ToList();
            }

            if (externalRollers.Contains(Id))
            {
                colors = colors
                    .Take(2)
                    .ToList();
            }

            return colors;
        }
    }
}

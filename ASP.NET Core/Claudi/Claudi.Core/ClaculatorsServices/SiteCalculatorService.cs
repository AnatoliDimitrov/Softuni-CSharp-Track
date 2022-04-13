namespace Claudi.Core.ClaculatorsServices
{
    using Microsoft.EntityFrameworkCore;

    using ViewModels.CalculatorViewModels;
    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    public class SiteCalculatorService : ISiteCalculatorService
    {
        private readonly IDeletableEntityRepository<ProductType> types;
        private readonly IDeletableEntityRepository<ProductModel> models;
        private readonly IDeletableEntityRepository<ProductExtra> extras;
        private readonly IDeletableEntityRepository<ProductColor> allColors;
        private readonly IDeletableEntityRepository<ConfiguredProduct> products;

        public SiteCalculatorService(IDeletableEntityRepository<ProductType> _types,
            IDeletableEntityRepository<ProductModel> _models,
            IDeletableEntityRepository<ProductExtra> _extras,
            IDeletableEntityRepository<ProductColor> _colors,
            IDeletableEntityRepository<ConfiguredProduct> _products)
        {
            this.types = _types;
            this.models = _models;
            this.extras = _extras;
            this.allColors = _colors;
            this.products = _products;
        }

        public async Task<List<TypeViewModel>> GetProductTypesAsync()
        {
            var productTypes = await types.AllAsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ShortName = t.NameShort,
                })
                .ToListAsync();

            return productTypes;
        }

        public async Task<List<ModelViewModel>> GetProductModelsAsync(int id)
        {
            var productModels = await models.All()
                .Where(p => p.OnCalculator == true && p.ProductTypeId == id)
                .Select(p => new ModelViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                })
                .ToListAsync();

            return productModels;
        }

        public async Task<List<ExtraViewModel>> GetProductExtras(int id)
        {
            var model = await models.AllAsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return await extras.AllAsNoTracking()
                .Where(e => e.OnClaculator == true && e.Models.Contains(model))
                .Select(e => new ExtraViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Group = e.Group,
                })
                .ToListAsync();
        }

        public async Task<List<ColorViewModel>> GetProductColors(int id)
        {
            var externalRollers = new int[] { 44, 45, 46 };
            var nets = new int[] { 61, 62, 63, 64, 65, 66, 67 };

            var model = await models.AllAsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            var filter = id switch
            {
                var x when (x >= 1 && x <= 9) => "25mm",
                13 => "25mm",
                14 => "50mm",
                58 => "Para",
                _ => null
            };

            var colors = await allColors.AllAsNoTracking()
                .Where(c => c.Models.Contains(model))
                .Where(c => c.Group != "Профили" && c.Group != "profils")
                .Select(p => new ColorViewModel()
                {
                    Id = p.Id,
                    Number = p.Number,
                    Group = p.Group,
                    Url = p.ImageUrl,
                })
                .OrderBy(c => c.Number.Length)
                .ToListAsync();

            var ultimate = new int[] { 7, 8, 9 };
            var ultimateColors = new string[] { "101", "102", "121", "107", "311", "371", "0150", "4459", "7010", "7113", "991", "992", "993", "994", "995", "996", "997", "998", "0150p", "4459p", "7010p", "7327", "7332", "7333", "7346", "7418", "8595" };

            if (ultimate.Contains(id))
            {
                colors = colors
                    .Where(c => ultimateColors.Contains(c.Number))
                    .ToList();
            }

            if (filter != null)
            {
                colors = colors
                    .Where(c => c.Group == filter).ToList();
            }

            if (nets.Contains(id))
            {
                return new List<ColorViewModel>()
                {
                    new ColorViewModel()
                    {
                        Number = "Бял",
                        Group = "nets",
                        Url = "/storage/samples/nets/single_Комарници/bial.jpg"
                    },
                    new ColorViewModel()
                    {
                        Number = "Кафяв",
                        Group = "nets",
                        Url = "/storage/samples/nets/single_Комарници/kafiav.jpg"
                    },
                    new ColorViewModel()
                    {
                        Number = "Имитация на дърво",
                        Group = "nets",
                        Url = "/storage/samples/nets/single_Комарници/zldab.jpg"
                    },
                    new ColorViewModel()
                    {
                        Number = "Цвят по RAL",
                        Group = "nets",
                        Url = "/storage/samples/nets/single_Комарници/bial.jpg"
                    },
                };
            }

            if (externalRollers.Contains(id))
            {
                colors = colors
                    .OrderBy(c => c.Number)
                    .Take(2)
                    .ToList();
            }

            return colors;
        }

        public async Task<bool> SaveProduct(SaveProductViewModel model, string userId)
        {
            var price = model.Price.Replace(" лв.", "");

            try
            {
                var type = await types.All()
                    .FirstOrDefaultAsync(t => t.Name == model.Type);

                var productModel = await models.All()
                    .FirstOrDefaultAsync(t => t.Name == model.ModelId);

                var color = await allColors.All()
                    .FirstOrDefaultAsync(c => c.Number == model.ColorId);

                var currentExtras = new List<ProductExtra>();

                

                var product = new ConfiguredProduct()
                {
                    Type = type,
                    Model = productModel,
                    Color = color,
                    UserId = userId,
                    Extras = currentExtras,
                    CreatedOn = DateTime.UtcNow,
                    Price = decimal.Parse(price),
                    Height = decimal.Parse(model.Height),
                    Width = decimal.Parse(model.Width),
                    Quantity = int.Parse(model.Quantity),
                    SquareMeters = decimal.Parse(model.SquareMeters),
                };

                foreach (var item in model.Extras)
                {
                    var extra = await extras.All()
                        .FirstOrDefaultAsync(e => e.Name == item);

                    product.Extras.Add(extra);
                }

                //throw new ArgumentException();

                await products.AddAsync(product);

                await products.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

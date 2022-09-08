namespace Claudi.Core.MyProductsServices
{
    using Microsoft.EntityFrameworkCore;

    using ViewModels.MyProductsViewModels;

    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;
    public class MyProductsService : IMyProductsService
    {
        private readonly IDeletableEntityRepository<ConfiguredProduct> _products;
        private readonly IDeletableEntityRepository<ProductColor> _colors;
        private readonly IDeletableEntityRepository<ProductType> _types;
        private readonly IDeletableEntityRepository<ProductModel> _models;
        private readonly IDeletableEntityRepository<ProductExtra> _extras;

        public MyProductsService(IDeletableEntityRepository<ConfiguredProduct> products,
            IDeletableEntityRepository<ProductColor> colors,
            IDeletableEntityRepository<ProductType> types,
            IDeletableEntityRepository<ProductModel> models,
            IDeletableEntityRepository<ProductExtra> extras)
        {
            this._products = products;
            this._colors = colors;
            this._types = types;
            this._models = models;
            this._extras = extras;
        }

        public async Task<List<MyProductViewModel>> GetProductsAsync(string userId)
        {
            var configuredProducts = await _products.AllAsNoTracking()
                .Where(p => p.UserId == userId)
                .OrderBy(p => p.Type.Id)
                .ToListAsync();

            var products = new List<MyProductViewModel>();

            foreach (var configuredProduct in configuredProducts)
            {
                var color = _colors.All().FirstOrDefault(c => c.Id == configuredProduct.ColorId);

                var type = _types.All().FirstOrDefault(t => t.Id == configuredProduct.TypeId);

                var model = _models.All().FirstOrDefault(m => m.Id == configuredProduct.ModelId);

                var extra = _extras.All()
                    .Where(e => e.ConfiguredProducts.Contains(configuredProduct))
                    .Select(e => e.Name)
                    .ToList();

                var product = new MyProductViewModel()
                {

                    Id = configuredProduct.Id,
                    Type = type.Name,
                    Model = model.Name,
                    Color = color.Number,
                    ColorGroup = color.Group,
                    Width = configuredProduct.Width,
                    Height = configuredProduct.Height,
                    Quantity = configuredProduct.Quantity,
                    SquareMeters = configuredProduct.SquareMeters,
                    Extras = extra,
                    Price = configuredProduct.Price,
                };

                products.Add(product);
            }

            return products;
        }

        public async Task DeleteProduct(string id)
        {
            var product = await _products.All()
                .FirstOrDefaultAsync(p => p.Id == id);

            _products.Delete(product);

            await _products.SaveChangesAsync();
        }
    }
}

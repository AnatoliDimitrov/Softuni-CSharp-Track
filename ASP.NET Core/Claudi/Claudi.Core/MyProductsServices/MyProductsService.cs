namespace Claudi.Core.MyProductsServices
{
    using Microsoft.EntityFrameworkCore;

    using ViewModels.MyProductsViewModels;

    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;
    public class MyProductsService : IMyProductsService
    {
        private readonly IDeletableEntityRepository<ConfiguredProduct> _products;

        public MyProductsService(IDeletableEntityRepository<ConfiguredProduct> products)
        {
            this._products = products;
        }

        public async Task<List<MyProductViewModel>> GetProductsAsync(string userId)
        {
            var products = await _products.AllAsNoTracking()
                .Where(p => p.UserId == userId)
                .OrderBy(p => p.Type.Id)
                .Select(p => new MyProductViewModel()
                {
                    Id = p.Id,
                    Type = p.Type.Name,
                    Model = p.Model.Name,
                    Color = p.Color.Number,
                    ColorGroup = p.Color.Group,
                    Width = p.Width,
                    Height = p.Height,
                    Quantity = p.Quantity,
                    SquareMeters = p.SquareMeters,
                    Extras = p.Extras
                        .Select(e => e.Name)
                        .ToList(),
                    Price = p.Price,
                })
                .ToListAsync();

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

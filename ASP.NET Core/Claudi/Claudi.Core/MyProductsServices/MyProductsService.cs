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
                .Select(p => new MyProductViewModel()
                {
                    Id = p.Id,
                    TypeId = p.TypeId,
                    Model = p.Model.Name,
                    Color = p.Color.Name,
                    Width = p.Width,
                    Height = p.Height,
                    Quantity = p.Quantity,
                    Extras = p.Extras
                        .Select(e => e.Id)
                        .ToList()
                })
                .ToListAsync();

            return products;
        }
    }
}

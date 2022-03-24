namespace Claudi.Core.ProductsServices
{
    using Microsoft.EntityFrameworkCore;

    using ViewModels.CommonViewModels;

    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;
    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<ProductType> _types;

        public ProductsService(IDeletableEntityRepository<ProductType> types)
        {
            this._types = types;
        }

        public async Task<IEnumerable<TypeViewModel>> GetAllTypesAsync()
        {
            return await _types.All()
                .OrderBy(t => t.Id)
                .Select(t => new TypeViewModel
                {
                    Name = t.Name,
                    EnglishNameShort = t.EnglishNameShort,
                })
                .ToListAsync();
        }
    }
}

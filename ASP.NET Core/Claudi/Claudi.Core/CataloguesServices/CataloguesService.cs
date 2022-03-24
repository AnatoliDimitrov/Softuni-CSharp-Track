using Claudi.Core.ViewModels.CataloguesViewModels;

namespace Claudi.Core.CataloguesServices
{

    using Microsoft.EntityFrameworkCore;

    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    using ViewModels.CommonViewModels;

    public class CataloguesService : ICataloguesService
    {
        private readonly IDeletableEntityRepository<ProductType> _types;
        private readonly IDeletableEntityRepository<ProductCatalogue> _catalogues;

        public CataloguesService(IDeletableEntityRepository<ProductType> types,
            IDeletableEntityRepository<ProductCatalogue> catalogues)
        {
            this._types = types;
            this._catalogues = catalogues;
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

        public async Task<IEnumerable<CatalogueViewModel>> GetAllCatalaguesAsync(int type)
        {
            return await _catalogues.All()
                .Where(c => c.TypeId == type)
                .OrderBy(c => c.Number)
                .Select(c => new CatalogueViewModel
                {
                    Number = c.Number,
                    Group = c.Group,
                    TypeId = c.TypeId,
                    CssClass = c.CssClass,
                    ImageUrl = c.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CataloguesGroupsViewModel>> GetAllGroupsAsync(int typeId)
        {
            return await _catalogues.All()
                .Where(c => c.TypeId == typeId)
                .OrderBy(c => c.CssClass)
                .Select(c => new CataloguesGroupsViewModel
                {
                    Group = c.Group,
                    CssClass = c.CssClass,
                })
                .Distinct()
                .ToListAsync();
        }
    }
}

namespace Claudi.Core.CommonServices
{
    using Microsoft.EntityFrameworkCore;

    using ViewModels.CommonViewModels;

    using Infrastructure.Repositories;
    using Infrastructure.Data.Models.DataBaseModels;

    public class CommonService : ICommonService
    {
        private readonly IDeletableEntityRepository<ProductType> _types;

        public CommonService(IDeletableEntityRepository<ProductType> types)
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

namespace Claudi.Core.ColorsServices
{
    using Claudi.Core.ViewModels.ColorsViewModels;
    using Claudi.Core.ViewModels.CommonViewModels;
    using Claudi.Infrastructure.Data.Models.DataBaseModels;
    using Claudi.Infrastructure.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class ColorsService : IColorsService
    {
        private readonly IDeletableEntityRepository<ProductColor> _allColors;
        private readonly IDeletableEntityRepository<ProductType> _types;

        public ColorsService(IDeletableEntityRepository<ProductColor> colors,
            IDeletableEntityRepository<ProductType> types)
        {
            this._allColors = colors;
            this._types = types;
        }

        public async Task<IEnumerable<ColorViewModel>> GetAllColorsAsync(string type)
        {
            return await _allColors.All()
                .Where(c => c.Name == type)
                .OrderBy(c => c.CssClass)
                .Select(c => new ColorViewModel
                {
                    Number = c.Number,
                    Name = c.Name,
                    Real = c.Real,
                    Group = c.Group,
                    CssClass = c.CssClass,
                    ImageUrl = c.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ColorViewModel>> GetAllVerticalColorsAsync()
        {
            var models = new[] { "89mm", "127mm", "al"};

            return await _allColors.All()
                .Where(c => models.Contains(c.Name))
                .Select(c => new ColorViewModel
                {
                    Number = c.Number,
                    Name = c.Name,
                    Real = c.Real,
                    Group = c.Group,
                    CssClass = c.Name,
                    ImageUrl = c.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ColorsGroupsViewModel>> GetAllGroupsAsync(string type)
        {
            return await _allColors.All()
                .Where(c => c.Name == type)
                .OrderBy(c => c.CssClass)
                .Select(c => new ColorsGroupsViewModel
                {
                    Group = c.Group,
                    CssClass = c.CssClass,
                })
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<ColorsGroupsViewModel>> GetAllVerticalGroupsAsync()
        {
            var models = new[] { "89mm", "127mm", "al" };

            return await _allColors.All()
                .Where(c => models.Contains(c.Name))
                .Select(c => new ColorsGroupsViewModel
                {
                    Group = c.Name,
                    CssClass = c.Name,
                })
                .Distinct()
                .ToListAsync();
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

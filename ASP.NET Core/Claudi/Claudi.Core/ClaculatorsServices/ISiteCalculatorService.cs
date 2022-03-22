using Claudi.Core.ViewModels.CalculatorViewModels;

namespace Claudi.Core.ClaculatorsServices
{
    public interface ISiteCalculatorService
    {
        Task<List<TypeViewModel>> GetProductTypesAsync();

        Task<List<ModelViewModel>> GetProductModelsAsync(int id);

        Task<List<ExtraViewModel>> GetProductExtras(int id);

        Task<List<ColorViewModel>> GetProductColors(int id);

        Task<bool> SaveProduct(SaveProductViewModel model, string userId);
    }
}

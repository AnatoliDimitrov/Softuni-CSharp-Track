namespace Claudi.Core.ClaculatorsServices
{
    using ViewModels.CalculatorViewModels;

    public interface ISiteCalculatorService
    {
        Task<List<TypeViewModel>> GetProductTypesAsync();

        Task<List<ModelViewModel>> GetProductModelsAsync(int id);

        Task<List<ExtraViewModel>> GetProductExtras(int id);

        Task<List<ColorViewModel>> GetProductColors(int id);

        Task<bool> SaveProduct(SaveProductViewModel model, string userId);
    }
}

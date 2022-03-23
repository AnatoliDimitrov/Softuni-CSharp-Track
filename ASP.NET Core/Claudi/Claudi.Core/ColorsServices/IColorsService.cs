namespace Claudi.Core.ColorsServices
{
    using Claudi.Core.ViewModels.ColorsViewModels;
    using Claudi.Core.ViewModels.CommonViewModels;

    public interface IColorsService
    {
        Task<IEnumerable<ColorViewModel>> GetAllColorsAsync(string type);

        Task<IEnumerable<ColorsGroupsViewModel>> GetAllGroupsAsync(string type);

        Task<IEnumerable<TypeViewModel>> GetAllTypesAsync();
    }
}

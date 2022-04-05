namespace Claudi.Core.ColorsServices
{
    using ViewModels.ColorsViewModels;
    using ViewModels.CommonViewModels;

    public interface IColorsService
    {
        Task<IEnumerable<ColorViewModel>> GetAllColorsAsync(string type);

        Task<IEnumerable<ColorsGroupsViewModel>> GetAllGroupsAsync(string type);

        Task<IEnumerable<TypeViewModel>> GetAllTypesAsync();

        Task<IEnumerable<ColorViewModel>> GetAllVerticalColorsAsync();

        Task<IEnumerable<ColorsGroupsViewModel>> GetAllVerticalGroupsAsync();
    }
}

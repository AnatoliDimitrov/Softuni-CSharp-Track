namespace Claudi.Core.CataloguesServices
{
    using ViewModels.CataloguesViewModels;
    using ViewModels.CommonViewModels;

    public interface ICataloguesService
    {
        Task<IEnumerable<TypeViewModel>> GetAllTypesAsync();

        Task<IEnumerable<CatalogueViewModel>> GetAllCatalaguesAsync(int type);

        Task<IEnumerable<CataloguesGroupsViewModel>> GetAllGroupsAsync(int typeId);
    }
}

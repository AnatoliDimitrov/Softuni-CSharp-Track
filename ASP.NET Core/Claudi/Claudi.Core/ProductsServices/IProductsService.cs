namespace Claudi.Core.ProductsServices
{
    using ViewModels.CommonViewModels;

    public interface IProductsService
    {
        Task<IEnumerable<TypeViewModel>> GetAllTypesAsync();
    }
}

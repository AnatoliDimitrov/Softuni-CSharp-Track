namespace Claudi.Core.MyProductsServices
{
    using ViewModels.MyProductsViewModels;

    public interface IMyProductsService
    {
        Task<List<MyProductViewModel>> GetProductsAsync(string userId);

        Task DeleteProduct(string id);
    }
}

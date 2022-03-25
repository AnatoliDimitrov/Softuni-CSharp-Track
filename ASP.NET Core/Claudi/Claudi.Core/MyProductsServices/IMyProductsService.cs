namespace Claudi.Core.MyProductsServices
{
    using Claudi.Core.ViewModels.MyProductsViewModels;

    public interface IMyProductsService
    {
        Task<List<MyProductViewModel>> GetProductsAsync(string userId);
    }
}

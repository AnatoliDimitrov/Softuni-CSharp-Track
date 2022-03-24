namespace Claudi.Core.CommonServices
{
    using ViewModels.CommonViewModels;

    public interface ICommonService
    {
        Task<IEnumerable<TypeViewModel>> GetAllTypesAsync();
    }
}

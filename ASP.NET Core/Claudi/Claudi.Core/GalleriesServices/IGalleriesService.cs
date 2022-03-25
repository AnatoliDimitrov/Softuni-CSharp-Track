namespace Claudi.Core.GalleriesServices
{
    using ViewModels.GalleriesViewModels;

    public interface IGalleriesService
    {
        Task<IEnumerable<GalleryPictureViewModel>> GetAllPicturesAsync();

        Task<IEnumerable<GalleresGroupsViewModel>> GetAllGroupsAsync();
    }
}

namespace Claudi.Core.ViewModels.GalleriesViewModels
{
    public class GalleriesViewModel
    {
        public string Type { get; set; }

        public IEnumerable<GalleresGroupsViewModel> Groups { get; set; }

        public IEnumerable<GalleryPictureViewModel> Pictures { get; set; }
    }
}

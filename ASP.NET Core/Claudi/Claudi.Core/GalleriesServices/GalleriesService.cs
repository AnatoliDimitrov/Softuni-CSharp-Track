namespace Claudi.Core.GalleriesServices
{
    using Microsoft.EntityFrameworkCore;

    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    using ViewModels.GalleriesViewModels;

    public class GalleriesService : IGalleriesService
    {
        private readonly IDeletableEntityRepository<GalleryPicture> _pictures;

        public GalleriesService(IDeletableEntityRepository<GalleryPicture> pictures)
        {
            this._pictures = pictures;
        }

        public async Task<IEnumerable<GalleryPictureViewModel>> GetAllPicturesAsync()
        {
            return await _pictures.All()
                .OrderBy(c => c.CssClass)
                .Select(c => new GalleryPictureViewModel
                {
                    Group = c.Group,
                    CssClass = c.CssClass,
                    ImageUrl = c.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<GalleresGroupsViewModel>> GetAllGroupsAsync()
        {
            return await _pictures.All()
                .OrderBy(c => c.CssClass)
                .Select(c => new GalleresGroupsViewModel
                {
                    Group = c.Group,
                    CssClass = c.CssClass,
                })
                .Distinct()
                .ToListAsync();
        }
    }
}

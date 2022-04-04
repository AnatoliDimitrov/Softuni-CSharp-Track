namespace Claudi.Core.Administration.DashboardServices
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using ViewModels.AdministrationViewModels.DashboardViewModels;

    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    public class DashboardService : IDashboardService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IDeletableEntityRepository<ProductColor> _colors;
        private readonly IDeletableEntityRepository<ProductCatalogue> _catalogues;
        private readonly IDeletableEntityRepository<GalleryPicture> _galleryPictures;

        public DashboardService(UserManager<IdentityUser> userManager,
            IDeletableEntityRepository<ProductColor> colors,
            IDeletableEntityRepository<ProductCatalogue> catalogues,
            IDeletableEntityRepository<GalleryPicture> galleryPictures)
        {
            this._userManager = userManager;
            this._colors = colors;
            this._catalogues = catalogues;
            this._galleryPictures = galleryPictures;
        }

        public async Task<DashboardVeiwModel> GetDashboardInfo()
        {
            var accounts = _userManager.Users.Count();
            var admins = await _userManager.GetUsersInRoleAsync("Administrator");
            var samples = await _colors.AllAsNoTracking().CountAsync();
            var catalogues = await _catalogues.AllAsNoTracking().CountAsync();
            var gallery = await _galleryPictures.AllAsNoTracking().CountAsync();

            var dashboardInfo = new DashboardVeiwModel
            {
                AccountsCount = accounts,
                AdministratorsCount = admins.Count,
                SamplesCount = samples,
                CataloguesCount = catalogues,
                GalleryCount = gallery
            };

            return dashboardInfo;
        }
    }
}

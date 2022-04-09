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
            var dashboardInfo = new DashboardVeiwModel();

            try
            {
                var accounts = _userManager.Users.Count();
                var admins = await _userManager.GetUsersInRoleAsync("Administrator");
                var samples = await _colors.AllAsNoTracking().CountAsync();
                var catalogues = await _catalogues.AllAsNoTracking().CountAsync();
                var gallery = await _galleryPictures.AllAsNoTracking().CountAsync();

                dashboardInfo = new DashboardVeiwModel
                {
                    Created = true,
                    AccountsCount = accounts,
                    AdministratorsCount = admins.Count,
                    SamplesCount = samples,
                    CataloguesCount = catalogues,
                    GalleryCount = gallery
                };

                //throw new ArgumentException();
            }
            catch (Exception)
            {
                dashboardInfo.Created = false;
            }

            return dashboardInfo;
        }
    }
}

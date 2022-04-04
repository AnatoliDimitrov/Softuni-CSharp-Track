using System;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading.Tasks;
using Claudi.Core.Administration.DashboardServices;
using Xunit;
using Claudi.Infrastructure.Data.Models.DataBaseModels;
using Claudi.Infrastructure.Repositories;
using System.Linq;
using Claudi.Core.ViewModels.AdministrationViewModels.DashboardViewModels;
using Claudi.Infrastructure.Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Claudi.Tests.Administration.Dashboard
{
    public class DashboardServiceTests
    {

        //[Fact]

        //public async Task GetDashboardInfoReturnsDashboardViewModel()
        //{
        //    var manager = GetMockUserManager().Object;
        //    await manager.CreateAsync(new IdentityUser()
        //    {
        //        Id = "test",
        //        Email = "test",
        //        EmailConfirmed = true,
        //        NormalizedEmail = "test",
        //    });

        //    var user = manager.Users.Where(u => u.Id == "test").FirstOrDefault();

        //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
        //        .UseInMemoryDatabase(Guid.NewGuid().ToString());

        //    await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
        //    dbContext.Add(new ProductColor()
        //    {
        //        Name = "test",
        //        CssClass = "test",
        //        ImageUrl = "test",
        //        Number = "test",
        //        Group = "test",
        //    });
        //    dbContext.Add(new ProductCatalogue()
        //    {
        //        Number = 1,
        //        CssClass = "test",
        //        ImageUrl = "test",
        //        TypeId = 1,
        //        Group = "test",
        //    });
        //    dbContext.Add(new GalleryPicture()
        //    {
        //        Group = "test",
        //        CssClass = "test",
        //        ImageUrl = "test",
        //    });

        //    dbContext.SaveChanges();

        //    using var colorsRepo = new EfDeletableEntityRepository<ProductColor>(dbContext);
        //    using var cataloguesRepo = new EfDeletableEntityRepository<ProductCatalogue>(dbContext);
        //    using var galleryRepo = new EfDeletableEntityRepository<GalleryPicture>(dbContext);

        //    await manager.AddToRoleAsync(user, "Administrator");

        //    var expected = new DashboardVeiwModel() 
        //    { 
        //        AccountsCount = 0, 
        //        AdministratorsCount = 0, 
        //        CataloguesCount = 1, 
        //        GalleryCount = 1, 
        //        SamplesCount = 1,
        //    };

        //    var service = new DashboardService(manager, colorsRepo, cataloguesRepo, galleryRepo);
        //    var actual = await service.GetDashboardInfo();

        //    expected.Should().BeEquivalentTo(actual);
        //}

        //private Mock<UserManager<IdentityUser>> GetMockUserManager()
        //{
        //    var userStoreMock = new Mock<IUserStore<IdentityUser>>();
        //    var manager =  new Mock<UserManager<IdentityUser>>(
        //        userStoreMock.Object, null, null, null, null, null, null, null, null);

        //    //manager.Setup(x => x.GetUsersInRoleAsync(It.IsAny<string>()))
        //    //    .Returns(Task.FromResult(It.IsAny<IList<IdentityUser>>()));

        //    return manager;
        //}
    }
}

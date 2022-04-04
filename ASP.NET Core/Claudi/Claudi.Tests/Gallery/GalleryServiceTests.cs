namespace Claudi.Tests.Gallery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using Xunit;

    using Core.GalleriesServices;
    using Core.ViewModels.GalleriesViewModels;

    using Infrastructure.Data;
    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    public class GalleryServiceTests
    {
        [Fact]
        public async Task GetAllPicturesAsyncReturnsListOfGalleryPictureViewModel()
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new GalleryPicture()
            {
                Id = "test",
                Group = "test",
                CssClass = "test",
                ImageUrl = "test"
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<GalleryPicture>(dbContext);

            var expected = new List<GalleryPictureViewModel>();
            expected.Add(new GalleryPictureViewModel
            {
                Group = "test",
                CssClass = "test",
                ImageUrl = "test"
            });

            var service = new GalleriesService(repo);
            var actual = await service.GetAllPicturesAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllGroupsAsyncReturnsListOfGalleresGroupsViewModel()
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new GalleryPicture()
            {
                Group = "test",
                CssClass = "test",
                ImageUrl = "test"
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<GalleryPicture>(dbContext);

            var expected = new List<GalleresGroupsViewModel>();
            expected.Add(new GalleresGroupsViewModel
            {
                Group = "test",
                CssClass = "test",
            });

            var service = new GalleriesService(repo);
            var actual = await service.GetAllGroupsAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

    }
}

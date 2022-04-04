using Claudi.Core.ViewModels.ColorsViewModels;

namespace Claudi.Tests.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Xunit;

    using FluentAssertions;
    using Moq;

    using Core.ColorsServices;
    using Core.ViewModels.CommonViewModels;

    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;
    using Infrastructure.Data;

    public class ColorsServicesTests
    {
        [Fact]
        public async Task GetProductTypesAsyncReturnsListOfTypeViewModel()
        {
            var listColors = new List<ProductColor>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductType()
            {
                Id = 1,
                Name = "test",
                EnglishNameShort = "test",
                NameShort = "test",
                EnglishName = "test"
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductType>(dbContext);
            
            var colorsRepoMock = new Mock<IDeletableEntityRepository<ProductColor>>();
            colorsRepoMock
                .Setup(x => x.All())
                .Returns(listColors.AsQueryable());

            var expected = new List<TypeViewModel>();
            expected.Add(new TypeViewModel { Name = "test", EnglishNameShort = "test" });

            var service = new ColorsService(colorsRepoMock.Object, repo);
            var actual = await service.GetAllTypesAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllGroupsAsyncReturnsListOfColorsGroupsViewModel()
        {
            var listTypes = new List<ProductType>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductColor()
            {
                Id = "test",
                Name = "test",
                Number = "test",
                Real = "test",
                Group = "test",
                CssClass = "test",
                ImageUrl = "test"
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductColor>(dbContext);

            var typesRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            typesRepoMock
                .Setup(x => x.All())
                .Returns(listTypes.AsQueryable());

            var expected = new List<ColorViewModel>();
            expected.Add(new ColorViewModel
            {
                Name = "test",
                Number = "test",
                Real = "test",
                Group = "test",
                CssClass = "test",
                ImageUrl = "test"
            });

            var service = new ColorsService(repo, typesRepoMock.Object);
            var actual = await service.GetAllGroupsAsync("test");

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllVerticalGroupsAsyncReturnsListOfColorsGroupsViewModel()
        {
            var listTypes = new List<ProductType>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductColor()
            {
                Id = "test",
                Name = "89mm",
                Number = "test",
                Real = "test",
                Group = "89mm",
                CssClass = "89mm",
                ImageUrl = "test"
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductColor>(dbContext);

            var typesRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            typesRepoMock
                .Setup(x => x.All())
                .Returns(listTypes.AsQueryable());

            var expected = new List<ColorViewModel>();
            expected.Add(new ColorViewModel
            {
                Name = "89mm",
                Number = "test",
                Real = "test",
                Group = "89mm",
                CssClass = "89mm",
                ImageUrl = "test"
            });

            var service = new ColorsService(repo, typesRepoMock.Object);
            var actual = await service.GetAllVerticalGroupsAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllVerticalColorsAsyncReturnsListOfColorViewModel()
        {
            var listTypes = new List<ProductType>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductColor()
            {
                Id = "test",
                Name = "89mm",
                Number = "test",
                Real = "test",
                Group = "89mm",
                CssClass = "89mm",
                ImageUrl = "test"
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductColor>(dbContext);

            var typesRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            typesRepoMock
                .Setup(x => x.All())
                .Returns(listTypes.AsQueryable());

            var expected = new List<ColorViewModel>();
            expected.Add(new ColorViewModel
            {
                Name = "89mm",
                Number = "test",
                Real = "test",
                Group = "89mm",
                CssClass = "89mm",
                ImageUrl = "test"
            });

            var service = new ColorsService(repo, typesRepoMock.Object);
            var actual = await service.GetAllVerticalColorsAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllColorsAsyncReturnsListOfColorViewModel()
        {
            var listTypes = new List<ProductType>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductColor()
            {
                Id = "test",
                Name = "test",
                Number = "test",
                Real = "test",
                Group = "test",
                CssClass = "test",
                ImageUrl = "test"
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductColor>(dbContext);

            var typesRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            typesRepoMock
                .Setup(x => x.All())
                .Returns(listTypes.AsQueryable());

            var expected = new List<ColorViewModel>();
            expected.Add(new ColorViewModel
            {
                Name = "test",
                Number = "test",
                Real = "test",
                Group = "test",
                CssClass = "test",
                ImageUrl = "test"
            });

            var service = new ColorsService(repo, typesRepoMock.Object);
            var actual = await service.GetAllColorsAsync("test");

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }
    }
}

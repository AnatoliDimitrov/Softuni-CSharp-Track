namespace Claudi.Catalogues.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Moq;

    using Xunit;
    
    using Microsoft.EntityFrameworkCore;

    using FluentAssertions;

    using Core.ViewModels.CataloguesViewModels;
    using Core.ViewModels.CommonViewModels;
    using Core.CataloguesServices;

    using Infrastructure.Data;
    using Infrastructure.Repositories;
    using Infrastructure.Data.Models.DataBaseModels;
    using System.Linq;

    public class CataloguesServicesTests
    {
        [Fact]
        public async Task GetAllTypesAsyncReturnsListOfTypeViewModel()
        {
            var listCatalogues = new List<ProductCatalogue>();

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

            var cataloguesRepoMock = new Mock<IDeletableEntityRepository<ProductCatalogue>>();
            cataloguesRepoMock
                .Setup(x => x.All())
                .Returns(listCatalogues.AsQueryable());

            var expected = new List<TypeViewModel>();
            expected.Add(new TypeViewModel(){ Name = "test", EnglishNameShort = "test" });

            var service = new CataloguesService(repo, cataloguesRepoMock.Object);
            var actual = await service.GetAllTypesAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllCataloguesAsyncReturnsListOfCatalogueViewModel()
        {
            var listCatalogues = new List<ProductType>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductCatalogue()
            {
                Id = "test1",
                Number = 1,
                Group = "test1",
                TypeId = 1,
                CssClass = "test1",
                ImageUrl = "test1",
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductCatalogue>(dbContext);

            var typesRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            typesRepoMock
                .Setup(x => x.All())
                .Returns(listCatalogues.AsQueryable());

            var expected = new List<CatalogueViewModel>();
            expected.Add(new CatalogueViewModel(){
                Number = 1,
                Group = "test1",
                TypeId = 1,
                CssClass = "test1",
                ImageUrl = "test1",
            });

            var service = new CataloguesService(typesRepoMock.Object, repo);
            var actual = await service.GetAllCatalaguesAsync(1);

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllCataloguesAsyncReturnsListOfCataloguesGroupsViewModel()
        {
            var listCatalogues = new List<ProductType>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductCatalogue()
            {
                Id = "test",
                Number = 1,
                Group = "test",
                TypeId = 1,
                CssClass = "test",
                ImageUrl = "test",
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductCatalogue>(dbContext);

            var typesRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            typesRepoMock
                .Setup(x => x.All())
                .Returns(listCatalogues.AsQueryable());

            var expected = new List<CataloguesGroupsViewModel>();
            expected.Add(new CataloguesGroupsViewModel()
            {
                Group = "test",
                CssClass = "test",
            });

            var service = new CataloguesService(typesRepoMock.Object, repo);
            var actual = await service.GetAllGroupsAsync(1);

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }
    }
}
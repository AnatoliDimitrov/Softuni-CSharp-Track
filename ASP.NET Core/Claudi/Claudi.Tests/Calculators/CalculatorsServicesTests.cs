namespace Claudi.Tests.Calculators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;

    using Xunit;

    using FluentAssertions;


    using Microsoft.EntityFrameworkCore;

    using Core.ClaculatorsServices;
    using Core.ViewModels.CalculatorViewModels;

    using Infrastructure.Data;
    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    public class CalculatorsServicesTests
    {
        [Fact]
        public async Task GetProductTypesAsyncReturnsListOfTypeViewModel()
        {
            var listModels = new List<ProductModel>();
            var listExtras = new List<ProductExtra>();
            var listColors = new List<ProductColor>();
            var listConfiguredProducts = new List<ConfiguredProduct>();

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

            var modelsRepoMock = new Mock<IDeletableEntityRepository<ProductModel>>();
            modelsRepoMock
                .Setup(x => x.All())
                .Returns(listModels.AsQueryable());

            var extrasRepoMock = new Mock<IDeletableEntityRepository<ProductExtra>>();
            extrasRepoMock
                .Setup(x => x.All())
                .Returns(listExtras.AsQueryable());

            var configuredProductsRepoMock = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();
            configuredProductsRepoMock
                .Setup(x => x.All())
                .Returns(listConfiguredProducts.AsQueryable());

            var colorsRepoMock = new Mock<IDeletableEntityRepository<ProductColor>>();
            colorsRepoMock
                .Setup(x => x.All())
                .Returns(listColors.AsQueryable());

            var expected = new List<TypeViewModel>();
            expected.Add(new TypeViewModel { Id = 1, Name = "test", ShortName = "test" });

            var service = new SiteCalculatorService(repo, modelsRepoMock.Object, extrasRepoMock.Object, colorsRepoMock.Object, configuredProductsRepoMock.Object);
            var actual = await service.GetProductTypesAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetProductModelsAsyncReturnsListOfModelViewModel()
        {
            var listModels = new List<ProductType>();
            var listExtras = new List<ProductExtra>();
            var listColors = new List<ProductColor>();
            var listConfiguredProducts = new List<ConfiguredProduct>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductModel()
            {
                Id = 1,
                ProductTypeId = 1,
                Name = "test",
                EnglishName = "test",
                OnCalculator = true
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductModel>(dbContext);

            var modelsRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            modelsRepoMock
                .Setup(x => x.All())
                .Returns(listModels.AsQueryable());

            var extrasRepoMock = new Mock<IDeletableEntityRepository<ProductExtra>>();
            extrasRepoMock
                .Setup(x => x.All())
                .Returns(listExtras.AsQueryable());

            var configuredProductsRepoMock = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();
            configuredProductsRepoMock
                .Setup(x => x.All())
                .Returns(listConfiguredProducts.AsQueryable());

            var colorsRepoMock = new Mock<IDeletableEntityRepository<ProductColor>>();
            colorsRepoMock
                .Setup(x => x.All())
                .Returns(listColors.AsQueryable());

            var expected = new List<ModelViewModel>();
            expected.Add(new ModelViewModel() { Name = "test", Id = 1 });

            var service = new SiteCalculatorService(modelsRepoMock.Object, repo, extrasRepoMock.Object, colorsRepoMock.Object, configuredProductsRepoMock.Object);
            var actual = await service.GetProductModelsAsync(1);

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetProductModelsReturnsListOfColorViewModel()
        {
            var listModels = new List<ProductType>();
            var listExtras = new List<ProductExtra>();
            var listColors = new List<ProductColor>();
            var listConfiguredProducts = new List<ConfiguredProduct>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductModel()
            {
                Id = 1,
                ProductTypeId = 1,
                Name = "test",
                EnglishName = "test",
                OnCalculator = true
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductModel>(dbContext);

            var modelsRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            modelsRepoMock
                .Setup(x => x.All())
                .Returns(listModels.AsQueryable());

            var extrasRepoMock = new Mock<IDeletableEntityRepository<ProductExtra>>();
            extrasRepoMock
                .Setup(x => x.All())
                .Returns(listExtras.AsQueryable());

            var configuredProductsRepoMock = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();
            configuredProductsRepoMock
                .Setup(x => x.All())
                .Returns(listConfiguredProducts.AsQueryable());

            var colorsRepoMock = new Mock<IDeletableEntityRepository<ProductColor>>();
            colorsRepoMock
                .Setup(x => x.All())
                .Returns(listColors.AsQueryable());

            var expected = new List<ModelViewModel>();
            expected.Add(new ModelViewModel() { Name = "test", Id = 1 });

            var service = new SiteCalculatorService(modelsRepoMock.Object, repo, extrasRepoMock.Object, colorsRepoMock.Object, configuredProductsRepoMock.Object);
            var actual = await service.GetProductModelsAsync(1);

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetProductExtrasReturnsListOfExtraViewModel()
        {
            var listModels = new List<ProductType>();
            var listExtras = new List<ProductExtra>();
            var listColors = new List<ProductColor>();
            var listConfiguredProducts = new List<ConfiguredProduct>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var model = new ProductModel() { Id = 1, EnglishName = "test", Name = "test" };

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(model);
            dbContext.Add(new ProductExtra()
            {
                Id = 1,
                Name = "test",
                Group = 1,
                OnClaculator = true,
                Models = new List<ProductModel>() { model }
            });

            dbContext.SaveChanges();

            using var modelRepo = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var extraRepo = new EfDeletableEntityRepository<ProductExtra>(dbContext);

            var typesRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            typesRepoMock
                .Setup(x => x.All())
                .Returns(listModels.AsQueryable());

            var extrasRepoMock = new Mock<IDeletableEntityRepository<ProductExtra>>();
            extrasRepoMock
                .Setup(x => x.All())
                .Returns(listExtras.AsQueryable());

            var configuredProductsRepoMock = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();
            configuredProductsRepoMock
                .Setup(x => x.All())
                .Returns(listConfiguredProducts.AsQueryable());

            var colorsRepoMock = new Mock<IDeletableEntityRepository<ProductColor>>();
            colorsRepoMock
                .Setup(x => x.All())
                .Returns(listColors.AsQueryable());

            var expected = new List<ExtraViewModel>();
            expected.Add(new ExtraViewModel() { Id = 1, Group = 1, Name = "test" });

            var service = new SiteCalculatorService(typesRepoMock.Object, modelRepo, extraRepo, colorsRepoMock.Object, configuredProductsRepoMock.Object);
            var actual = await service.GetProductExtras(1);

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetProductColorsReturnsListOfExtraViewModel()
        {
            var listModels = new List<ProductType>();
            var listExtras = new List<ProductExtra>();
            var listColors = new List<ProductColor>();
            var listConfiguredProducts = new List<ConfiguredProduct>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var model = new ProductModel() { Id = 90, EnglishName = "test", Name = "test" };

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(model);
            dbContext.Add(new ProductColor()
            {
                Id = "test",
                Name = "test",
                Group = "test",
                ImageUrl = "test",
                CssClass = "test",
                Number = "test",
                Models = new List<ProductModel>() { model }
            });

            dbContext.SaveChanges();

            using var modelRepo = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var colorRepo = new EfDeletableEntityRepository<ProductColor>(dbContext);

            var typesRepoMock = new Mock<IDeletableEntityRepository<ProductType>>();
            typesRepoMock
                .Setup(x => x.All())
                .Returns(listModels.AsQueryable());

            var extrasRepoMock = new Mock<IDeletableEntityRepository<ProductExtra>>();
            extrasRepoMock
                .Setup(x => x.All())
                .Returns(listExtras.AsQueryable());

            var configuredProductsRepoMock = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();
            configuredProductsRepoMock
                .Setup(x => x.All())
                .Returns(listConfiguredProducts.AsQueryable());

            var colorsRepoMock = new Mock<IDeletableEntityRepository<ProductColor>>();
            colorsRepoMock
                .Setup(x => x.All())
                .Returns(listColors.AsQueryable());

            var expected = new List<ColorViewModel>();
            expected.Add(new ColorViewModel() { Id = "test", Group = "test", Number = "test", Url = "test" });

            var service = new SiteCalculatorService(typesRepoMock.Object, modelRepo, extrasRepoMock.Object, colorRepo, configuredProductsRepoMock.Object);
            var actual = await service.GetProductColors(90);

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task SaveConfiguredProductSuccessful()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var model = new ProductModel() { Id = 1, EnglishName = "test", Name = "test" };

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(model);
            dbContext.Add(new ProductColor()
            {
                Id = "test",
                Name = "test",
                Group = "test",
                ImageUrl = "test",
                CssClass = "test",
                Number = "test",
                Models = new List<ProductModel>() { model }
            });
            dbContext.Add(new ProductExtra()
            {
                Id = 1,
                Name = "test",
                EnglishName = "test"
            });
            dbContext.Add(new ProductType()
            {
                Id = 1,
                Name = "test",
                EnglishName = "test",
                NameShort = "test",
                EnglishNameShort = "test",
            });

            dbContext.SaveChanges();

            using var cpRepo = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var colorRepo = new EfDeletableEntityRepository<ProductColor>(dbContext);
            using var typesRepo = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var modelsRepo = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var extrasRepo = new EfDeletableEntityRepository<ProductExtra>(dbContext);

            var product = new SaveProductViewModel()
            {
                Type = "1",
                ModelId = "1",
                ColorId = "test",
                Width = "100",
                Height = "100",
                Quantity = "1",
                SquareMeters = "1",
                Extras = new List<string>() { "test" },
                Price = "100"
            };

            var service = new SiteCalculatorService(typesRepo, modelsRepo, extrasRepo, colorRepo, cpRepo);
            var actual = await service.SaveProduct(product,"test");

            Assert.True(actual);
        }

        [Fact]
        public async Task SaveConfiguredProductreturnsFalse()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var model = new ProductModel() { Id = 1, EnglishName = "test", Name = "test" };

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(model);
            dbContext.Add(new ProductExtra()
            {
                Id = 1,
                Name = "test",
                EnglishName = "test"
            });
            dbContext.Add(new ProductType()
            {
                Id = 2,
                Name = "test",
                EnglishName = "test",
                NameShort = "test",
                EnglishNameShort = "test",
            });

            dbContext.SaveChanges();

            using var cpRepo = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var colorRepo = new EfDeletableEntityRepository<ProductColor>(dbContext);
            using var typesRepo = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var modelsRepo = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var extrasRepo = new EfDeletableEntityRepository<ProductExtra>(dbContext);

            var product = new SaveProductViewModel()
            {
                Type = "1",
                ModelId = "1",
                ColorId = "test",
                Width = "100",
                Height = "100",
                Quantity = "1",
                SquareMeters = "1",
                Extras = new List<string>() { "test" },
                Price = "100"
            };

            var service = new SiteCalculatorService(typesRepo, modelsRepo, extrasRepo, colorRepo, cpRepo);
            var actual = await service.SaveProduct(product, "test");

            Assert.False(actual);
        }
    }
}

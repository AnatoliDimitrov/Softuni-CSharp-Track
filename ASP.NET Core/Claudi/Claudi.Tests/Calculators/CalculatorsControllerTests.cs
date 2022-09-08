using System.Threading;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;

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
    using Microsoft.AspNetCore.Mvc;

    using Core.ClaculatorsServices;
    using Core.ViewModels.CalculatorViewModels;
    
    using Claudi.Web.Controllers;

    using Infrastructure.Data;
    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    public class CalculatorsControllerTests
    {
        [Fact]
        public async Task GetProductTypesAsyncWorks()
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

            var options = Options.Create<MemoryDistributedCacheOptions>(new MemoryDistributedCacheOptions());
            IDistributedCache cache = new MemoryDistributedCache(options);

            var expected = new List<TypeViewModel>();
            expected.Add(new TypeViewModel { Id = 1, Name = "test", ShortName = "test" });

            var service = new SiteCalculatorService(repo, modelsRepoMock.Object, extrasRepoMock.Object, colorsRepoMock.Object, configuredProductsRepoMock.Object);

            var controller = new CalculatorsController(service, cache);
            //var controller = new CalculatorsController(service);

            var result = await controller.Index("test");

            Assert.IsType(typeof(ViewResult), result);
        }

        [Fact]
        public async Task GetProductModelsAsyncWorks()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductType()
            {
                Id = 1,
                Name = "test",
                NameShort = "test",
                EnglishName = "test",
                EnglishNameShort = "test",
            });
            dbContext.Add(new ProductColor()
            {
                Name = "test",
                CssClass = "test",
                ImageUrl = "test",
                Number = "test",
                Group = "test",
            });
            dbContext.Add(new ProductModel()
            {
                Id = 1,
                ProductTypeId = 1,
                Name = "test",
                EnglishName = "test",
                OnCalculator = true
            });
            dbContext.Add(new ProductExtra()
            {
                Id = 1,
                Name = "test",
                EnglishName = "test"
            });

            dbContext.SaveChanges();

            using var colorsRepo = new EfDeletableEntityRepository<ProductColor>(dbContext);
            using var productsRepo = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var modelsRepo = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var configuredRepo = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var extrasRepo = new EfDeletableEntityRepository<ProductExtra>(dbContext);

            

            var service = new SiteCalculatorService(productsRepo, modelsRepo, extrasRepo, colorsRepo, configuredRepo);
            
            var options = Options.Create<MemoryDistributedCacheOptions>(new MemoryDistributedCacheOptions());
            IDistributedCache cache = new MemoryDistributedCache(options);

            var controller = new CalculatorsController(service, cache);
            //var controller = new CalculatorsController(service);

            var expected = new List<ModelViewModel>();
            expected.Add(new ModelViewModel() { Name = "test", Id = 1 });

            var actual = await controller.ProductModels(1);

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task ProductColorsWorks()
        {
            var listModels = new List<ProductModel>();
            var listExtras = new List<ProductExtra>();
            var listColors = new List<ProductColor>();
            var listConfiguredProducts = new List<ConfiguredProduct>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            var model = new ProductModel()
            {
                Id = 90,
                ProductTypeId = 1,
                Name = "test",
                EnglishName = "test",
                OnCalculator = true
            };
            dbContext.Add(new ProductType()
            {
                Id = 1,
                Name = "test",
                NameShort = "test",
                EnglishName = "test",
                EnglishNameShort = "test",
            });
            dbContext.Add(new ProductColor()
            {
                Name = "test",
                CssClass = "test",
                ImageUrl = "test",
                Number = "test",
                Group = "test",
                Models = new List<ProductModel>(){model}
            });
            dbContext.Add(model);
            dbContext.Add(new ProductExtra()
            {
                Id = 1,
                Name = "test",
                EnglishName = "test"
            });

            dbContext.SaveChanges();

            using var colorsRepo = new EfDeletableEntityRepository<ProductColor>(dbContext);
            using var productsRepo = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var modelsRepo = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var configuredRepo = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var extrasRepo = new EfDeletableEntityRepository<ProductExtra>(dbContext);

            var service = new SiteCalculatorService(productsRepo, modelsRepo, extrasRepo, colorsRepo, configuredRepo);

            var options = Options.Create<MemoryDistributedCacheOptions>(new MemoryDistributedCacheOptions());
            IDistributedCache cache = new MemoryDistributedCache(options);

            var controller = new CalculatorsController(service, cache);
            //var controller = new CalculatorsController(service);

            var expected = new List<ColorViewModel>();
            expected.Add(new ColorViewModel() {
                Number = "test",
                Group = "test",
                Url = "test",
                Id = "test"
            });

            var actual = await controller.ProductColors(90);

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
        }
    }
}

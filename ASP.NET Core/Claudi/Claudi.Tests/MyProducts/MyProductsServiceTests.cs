namespace Claudi.Tests.MyProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using Xunit;

    using Core.MyProductsServices;
    using Core.ViewModels.MyProductsViewModels;

    using Infrastructure.Data;
    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    public class MyProductsServiceTests
    {
        [Fact]
        public async Task GetProductsAsyncReturnsListOfMyProductViewModel()
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            var type = new ProductType()
            {
                Id = 1,
                Name = "test",
                EnglishNameShort = "test",
                NameShort = "test",
                EnglishName = "test",
            };
            var model = new ProductModel()
            {
                Id = 1,
                Name = "test",
                Type = type,
                EnglishName = "test",
            };
            var color = new ProductColor()
            {
                Id = "test",
                Name = "test",
                Group = "test",
                CssClass = "test",
                ImageUrl = "test",
                Number = "test",
            };
            dbContext.Add(color);
            dbContext.Add(type);
            dbContext.Add(model);
            dbContext.Add(new ConfiguredProduct()
            {
                Id = "test",
                Type = type,
                Model = model,
                Color = color,
                Width = 122,
                Height = 122,
                Quantity = 1,
                SquareMeters = 1,
                Extras = new List<ProductExtra>(){ new ProductExtra(){Name = "test"} },
                Price = 122,
                UserId = "test"
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);

            var expected = new List<MyProductViewModel>();
            expected.Add(new MyProductViewModel
            {
                Id = "test",
                Type = "test",
                Model = "test",
                Color = "test",
                ColorGroup = "test",
                Width = 122,
                Height = 122,
                Quantity = 1,
                SquareMeters = 1,
                Extras = new List<string>() { "test" },
                Price = 122,
            });

            var service = new MyProductsService(repo);
            var actual = await service.GetProductsAsync("test");

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task DeleteProductDeletesConfiguredProduct()
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            var type = new ProductType()
            {
                Id = 1,
                Name = "test",
                EnglishNameShort = "test",
                NameShort = "test",
                EnglishName = "test",
            };
            var model = new ProductModel()
            {
                Id = 1,
                Name = "test",
                Type = type,
                EnglishName = "test",
            };
            var color = new ProductColor()
            {
                Id = "test",
                Name = "test",
                Group = "test",
                CssClass = "test",
                ImageUrl = "test",
                Number = "test",
            };
            dbContext.Add(color);
            dbContext.Add(type);
            dbContext.Add(model);
            dbContext.Add(new ConfiguredProduct()
            {
                Id = "test",
                Type = type,
                Model = model,
                Color = color,
                Width = 122,
                Height = 122,
                Quantity = 1,
                SquareMeters = 1,
                Extras = new List<ProductExtra>() { new ProductExtra() { Name = "test" } },
                Price = 122,
                UserId = "test"
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);

            var service = new MyProductsService(repo);
            await service.DeleteProduct("test");

            Assert.Empty(repo.All());
        }
    }
}

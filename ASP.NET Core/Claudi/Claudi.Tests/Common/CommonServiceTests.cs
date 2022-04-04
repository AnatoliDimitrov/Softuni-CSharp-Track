namespace Claudi.Tests.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using Xunit;

    using Core.CommonServices;
    using Core.ViewModels.CommonViewModels;

    using Infrastructure.Data;
    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    public class CommonServiceTests
    {
        [Fact]
        public async Task GetAllTypesAsyncReturnsListOfTypeViewModel()
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

            var expected = new List<TypeViewModel>();
            expected.Add(new TypeViewModel { Name = "test", EnglishNameShort = "test" });

            var service = new CommonService(repo);
            var actual = await service.GetAllTypesAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }
    }
}

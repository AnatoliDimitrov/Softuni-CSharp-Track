namespace Claudi.Tests.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using Infrastructure.Data;
    using Infrastructure.Data.Models.DataBaseModels;
    using Infrastructure.Repositories;

    public class EfDeletableEntityRepositoryTests
    {

        [Fact]
        public async Task AllWithDeletedWorks()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductType()
            {
                Id = 1,
                Name = "test",
                EnglishNameShort = "test",
                NameShort = "test",
                EnglishName = "test",
                IsDeleted = true
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductType>(dbContext);

            var actual = repo.AllWithDeleted();

            var expected = new ProductType
            {
                Id = 1,
                Name = "test",
                EnglishNameShort = "test",
                NameShort = "test",
                EnglishName = "test",
                IsDeleted = true
            };


            Assert.True(actual.Count() == 1);
            expected.Should().BeEquivalentTo(actual.ToList().FirstOrDefault());
        }

        [Fact]
        public async Task AllAsNoTrackingWithDeletedWorks()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Add(new ProductType()
            {
                Id = 1,
                Name = "test",
                EnglishNameShort = "test",
                NameShort = "test",
                EnglishName = "test",
                IsDeleted = true
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductType>(dbContext);

            var actual = repo.AllAsNoTrackingWithDeleted();

            var expected = new ProductType
            {
                Id = 1,
                Name = "test",
                EnglishNameShort = "test",
                NameShort = "test",
                EnglishName = "test",
                IsDeleted = true
            };


            Assert.True(actual.Count() == 1);
            expected.Should().BeEquivalentTo(actual.ToList().FirstOrDefault());
        }

        [Fact]
        public async Task HardDeleteWorks()
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

            dbContext.Add(type);

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductType>(dbContext);


            repo.HardDelete(type);

            var result = repo.All();

            Assert.False(result.ToList().Count == 0);
        }
        [Fact]
        public async Task UnDeleteWorks()
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
                IsDeleted = false,
            };

            dbContext.Add(type);

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<ProductType>(dbContext);


            repo.Undelete(type);

            Assert.False(type.IsDeleted);
        }
    }
}

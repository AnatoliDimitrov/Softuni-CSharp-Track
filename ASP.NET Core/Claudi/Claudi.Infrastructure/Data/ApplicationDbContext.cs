namespace Claudi.Infrastructure.Data
{
    using Claudi.Infrastructure.Data.Models.DataBaseModels;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ProductCatalogue> ProductCatalogues { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductExtra> ProductExtras { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ConfiguredProduct> ConfiguredProducts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductCatalogue>()
               .HasOne(e => e.Type)
               .WithMany(e => e.Catalogues)
               .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<ProductCatalogue>()
            //    .HasOne(e => e.Model)
            //    .WithMany(e => e.Catalogues)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ConfiguredProduct>()
                .HasOne(e => e.Type)
                .WithMany(e => e.ConfiguredProducts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ConfiguredProduct>()
                .HasOne(e => e.Model)
                .WithMany(e => e.ConfiguredProducts)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<ConfiguredProduct>()
            //    .HasOne(e => e.Color)
            //    .WithMany(e => e.ConfiguredProducts)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
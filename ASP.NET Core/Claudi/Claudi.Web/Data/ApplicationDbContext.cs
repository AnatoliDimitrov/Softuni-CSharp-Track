﻿using Claudi.Web.Models.DataBaseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Claudi.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public DbSet<ConfiguredProductExtra> ConfiguredProductExtras { get; set; }
        //public DbSet<ConfiguredProductUser> ConfiguredProductUsers { get; set; }
        //public DbSet<ModelColor> ModelColors { get; set; }
        //public DbSet<ModelExtra> ModelExtras { get; set; }
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

            builder.Entity<ProductCatalogue>()
                .HasOne(e => e.Model)
                .WithMany(e => e.Catalogues)
                .OnDelete(DeleteBehavior.Restrict);

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
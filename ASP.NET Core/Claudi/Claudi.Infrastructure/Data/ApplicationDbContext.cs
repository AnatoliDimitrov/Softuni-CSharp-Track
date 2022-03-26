namespace Claudi.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models.DataBaseModels;

    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly PasswordHasher<IdentityRole> hasher = new();

        public DbSet<ProductCatalogue> ProductCatalogues { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductExtra> ProductExtras { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ConfiguredProduct> ConfiguredProducts { get; set; }
        public DbSet<GalleryPicture> GalleryPictures { get; set; }

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

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "0e8e18fb-65b5-4bf9-9926-628afdb1c465", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "90b21bc9-9062-4142-b3f9-774e6797e080", // primary key
                    UserName = "apdimitrov@yahoo.com",
                    Email = "apdimitrov@yahoo.com",
                    NormalizedUserName = "apdimitrov@yahoo.com".ToUpper(),
                    NormalizedEmail = "apdimitrov@yahoo.com".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Anatoli84")
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "0e8e18fb-65b5-4bf9-9926-628afdb1c465",
                    UserId = "90b21bc9-9062-4142-b3f9-774e6797e080"
                }
            );

            builder.Entity<ConfiguredProduct>()
                .HasOne(e => e.Type)
                .WithMany(e => e.ConfiguredProducts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ConfiguredProduct>()
                .HasOne(e => e.Model)
                .WithMany(e => e.ConfiguredProducts)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
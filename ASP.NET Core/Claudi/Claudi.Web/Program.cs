using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Claudi.Web.Services;
using Claudi.Web.Data.Seeding;

using Claudi.Infrastructure.Data;
using Claudi.Infrastructure.Repositories;

using Claudi.Core.ClaculatorsServices;
using Claudi.Core.HomeServices;
using Claudi.Core.ColorsServices;
using Claudi.Core.GalleriesServices;
using Claudi.Core.ProductsServices;
using Claudi.Core.MyProductsServices;
using Claudi.Core.Administration.DashboardServices;
using Claudi.Core.Administration.AccountsServices;
using Claudi.Core.CataloguesServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(config =>
{
    config.SignIn.RequireConfirmedEmail = true;
    config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
        new TokenProviderDescriptor(
            typeof(CustomEmailConfirmationTokenProvider<IdentityUser>)));
    config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireManagerOnly", policy => policy.RequireRole("Administrator"));
});

builder.Services.AddTransient<CustomEmailConfirmationTokenProvider<IdentityUser>>();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<ISHEmailSender, SHEmailSender>();
builder.Services.AddTransient<ISiteCalculatorService, SiteCalculatorService>();
builder.Services.AddTransient<IColorsService, ColorsService>();
builder.Services.AddTransient<ICataloguesService, CataloguesService>();
builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<IGalleriesService, GalleriesService>();
builder.Services.AddTransient<IMyProductsService, MyProductsService>();
builder.Services.AddTransient<IDashboardService, DashboardService>();
builder.Services.AddTransient<IAccountsService, AccountsService>();

builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

builder.Services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

builder.Services.ConfigureApplicationCookie(o =>
{
    o.ExpireTimeSpan = TimeSpan.FromDays(30);
    o.SlidingExpiration = true;
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
       o.TokenLifespan = TimeSpan.FromDays(1));

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 20;
    options.Lockout.AllowedForNewUsers = true;
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "areaRoute",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}"
//    );
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

await Seeder.Seed(app);

app.Run();

public partial class Program { }
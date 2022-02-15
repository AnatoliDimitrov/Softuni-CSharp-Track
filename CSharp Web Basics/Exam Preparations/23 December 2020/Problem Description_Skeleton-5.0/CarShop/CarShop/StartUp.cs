namespace CarShop
{
    using MyWebServer;
    using CarShop.Data;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    using CarShop.Services.ModelsValidatorService;
    using CarShop.Repositories;
    using CarShop.Services.UsersService;
    using CarShop.Services.CarsService;
    using CarShop.Services.IssuesService;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<ApplicationDbContext>()
                    .Add<IViewEngine, CompilationViewEngine>())
                .WithServices(s => s
                    .Add<IModelValidatorService, ModelValidatorService>()
                    .Add<IRepository, Repository>()
                    .Add<IUserService, UserService>()
                    .Add<IIssueService, IssueService>()
                    .Add<ICarService, CarService>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.EnsureCreated())
                .Start();
    }
}

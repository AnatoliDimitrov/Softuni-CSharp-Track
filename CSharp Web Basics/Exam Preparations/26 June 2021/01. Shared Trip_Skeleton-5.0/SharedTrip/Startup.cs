namespace SharedTrip
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    using SharedTrip.Data;
    using SharedTrip.Repositories;
    using SharedTrip.Services.ModelsValidatorService;
    using SharedTrip.Services.TripsService;
    using SharedTrip.Services.UsersService;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<ApplicationDbContext>())
                .WithServices(s => s
                    .Add<IUserService, UserService>()
                    .Add<ITripService, TripService>()
                    .Add<IRepository, Repository>()
                    .Add<IModelValidatorService, ModelValidatorService>())
                .WithConfiguration<ApplicationDbContext>(c => c.Database.EnsureCreated())
                .Start();
    }
}

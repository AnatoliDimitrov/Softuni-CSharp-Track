namespace SharedTrip
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;

    using MyWebServer.Results.Views;
    using SharedTrip.Data;
    using SharedTrip.Services;

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
                    .Add<IValidator, Validator>()
                    .Add<IPasswordHasher, PasswordHasher>())
                .WithConfiguration<ApplicationDbContext>(c => c.Database.EnsureCreated())
                .Start();
    }
}

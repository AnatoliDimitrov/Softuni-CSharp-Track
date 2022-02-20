namespace FootballManager
{

    using System.Threading.Tasks;

    using FootballManager.Data;
    using FootballManager.Repositories;
    using FootballManager.Services.ModelsValidatorService;
    using FootballManager.Services.PlayersService;
    using FootballManager.Services.UsersService;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<FootballManagerDbContext>()
                    .Add<IViewEngine, CompilationViewEngine>())
            .WithServices(s => s
                    .Add<IModelValidatorService, ModelValidatorService>()
                    .Add<IRepository, Repository>()
                    .Add<IUserService, UserService>()
                    .Add<IPlayerService, PlayerService>())
                .WithConfiguration<FootballManagerDbContext>(context => context
                    .Database.EnsureCreated())
                .Start();
    }
}

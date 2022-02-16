namespace Git
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    
    using Git.Services.ModelsValidatorService;
    using Git.Repositories;
    using Git.Services.UsersService;
    using Git.Services.RepositoriesService;
    using Git.Data;

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
                    .Add<IRepositoryService, RepositoryService>()
                    .Add<IUserService, UserService>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.EnsureCreated())
                .Start();
    }
}

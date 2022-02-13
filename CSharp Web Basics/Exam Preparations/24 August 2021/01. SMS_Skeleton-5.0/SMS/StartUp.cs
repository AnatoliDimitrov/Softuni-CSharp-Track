namespace SMS
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    using SMS.Data;
    using SMS.Repositories;
    using SMS.Services.CartsService;
    using SMS.Services.ModelsValidatorService;
    using SMS.Services.ProductsService;
    using SMS.Services.UsersService;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<SMSDbContext>())
                .WithServices(s => s
                    .Add<IModelValidatorService, ModelValidatorService>()
                    .Add<IRepository, Repository>()
                    .Add<IUserService, UserService>()
                    .Add<IProductService, ProductService>()
                    .Add<ICartService, CartService>())
                .WithConfiguration<SMSDbContext>(c => c.Database.EnsureCreated())
                .Start();
    }
}
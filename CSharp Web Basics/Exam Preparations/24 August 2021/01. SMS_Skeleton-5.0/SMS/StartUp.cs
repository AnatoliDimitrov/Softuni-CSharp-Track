namespace SMS
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Data;
    using SMS.Services;

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
                    .Add<IValidator, Validator>()
                    .Add<IPasswordHasher, PasswordHasher>())
                .WithConfiguration<SMSDbContext>(c => c.Database.EnsureCreated())
                .Start();
    }
}
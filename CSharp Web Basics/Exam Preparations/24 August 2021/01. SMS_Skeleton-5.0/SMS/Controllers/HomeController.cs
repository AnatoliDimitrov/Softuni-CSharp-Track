namespace SMS.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using SMS.Models.Users;
    using SMS.Repositories;

    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(SMSDbContext _context)
        {
            this.repository = new Repository(_context);
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.IndexLoggedIn();
            }

            return this.View();
        }

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var products = repository.All<Product>()
                .ToList();

            var username = repository.All<User>()
                .Select(u => u.Username)
                .FirstOrDefault();

            var model = new ProductsViewModel() 
            { 
                Username = username,
                Products = products,
            };


            return this.View(model);
        }
    }
}
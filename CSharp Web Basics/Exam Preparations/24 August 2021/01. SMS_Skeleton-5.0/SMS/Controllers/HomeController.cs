namespace SMS.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;

    public class HomeController : Controller
    {
        private readonly SMSDbContext context;

        public HomeController(SMSDbContext _context)
        {
            this.context = _context;
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
            var products = this.context
                .Products
                .ToList();

            return this.View(products);
        }
    }
}
namespace SMS.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;

    [Authorize]
    public class CartsController : Controller
    {
        private readonly SMSDbContext context;

        public CartsController(SMSDbContext _context)
        {
            this.context = _context;
        }

        public HttpResponse AddProduct(string productId)
        {
            var product = this.context
                .Products
                .FirstOrDefault(p => p.Id == productId);

            var user = this.context
                .Users
                .FirstOrDefault(p => p.Id == this.User.Id);

            product.CartId = user.CartId;

            context.SaveChanges();

            return this.Details();
        }

        public HttpResponse Details()
        {
            var user = this.context
                .Users
                .FirstOrDefault(p => p.Id == this.User.Id);

            var products = this.context
                .Products
                .Where(p => p.CartId == user.CartId)
                .ToList();

            return this.View(products);
        }

        public HttpResponse Buy()
        {
            var user = this.context
                .Users
                .FirstOrDefault(p => p.Id == this.User.Id);

            this.context
                .Products
                .Where(p => p.CartId == user.CartId)
                .ToList()
                .ForEach(p => p.CartId = null);

            this.context.SaveChanges();

            return Redirect("/Home/Index");
        }
    }
}

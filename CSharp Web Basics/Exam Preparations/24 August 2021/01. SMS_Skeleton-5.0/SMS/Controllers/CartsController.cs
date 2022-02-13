namespace SMS.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SMS.Services.CartsService;

    [Authorize]
    public class CartsController : Controller
    {
        private readonly ICartService service;

        public CartsController( ICartService _service)
        {
            this.service = _service;
        }

        public HttpResponse AddProduct(string productId)
        {
            var errors = service.AddProduct(productId, this.User.Id);

            if (errors.Any())
            {
                return this.Error(errors);
                //return this.View();
            }

            return this.Details();
        }

        public HttpResponse Details()
        {
            var (errors, products) = service.CartDetails(this.User.Id);

            if (errors.Any())
            {
                return this.Error(errors);
                //return this.View();
            }

            return this.View(products);
        }

        public HttpResponse Buy()
        {
            var errors = service.BuyProducts(this.User.Id);

            if (errors.Any())
            {
                return this.Error(errors);
                //return this.View();
            }

            return Redirect("/Home/Index");
        }
    }
}

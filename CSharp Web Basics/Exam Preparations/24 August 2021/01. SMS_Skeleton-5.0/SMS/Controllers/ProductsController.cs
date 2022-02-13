namespace SMS.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models.Products;
    using SMS.Services.ProductsService;

    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateProductForm model)
        {
            var errors = productService.CreateProduct(model);

            if (errors.Any())
            {
                return this.Error(errors);
               // return this.View();
            }

            return this.Redirect("/Home/Index");
        }
    }
}

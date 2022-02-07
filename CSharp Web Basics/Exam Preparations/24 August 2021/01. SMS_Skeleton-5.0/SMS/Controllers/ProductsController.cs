namespace SMS.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using SMS.Models.Products;
    using SMS.Services;

    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly SMSDbContext context;

        public ProductsController(IValidator _validator, SMSDbContext _context)
        {
            this.validator = _validator;
            this.context = _context;
        }
        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateProductForm model)
        {
            var errors = validator.ValidateProduct(model);

            if (errors.Any())
            {
                return Error(errors);
            }


            this.context
                .Products
                .Add(new Product() 
                {
                    Name = model.Name,
                    Price = model.Price,
                    Cart = null
                });


            context.SaveChanges();

            return this.Redirect("/Home/Index");
        }
    }
}

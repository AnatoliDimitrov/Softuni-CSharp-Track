namespace CarShop.Controllers
{
    using CarShop.Services.CarsService;
    using CarShop.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    [Authorize]
    public class CarsController : Controller
    {
        private readonly ICarService service;

        public CarsController(ICarService _service)
        {
            this.service = _service;
        }

        public HttpResponse All()
        {
            var cars = service.AllCars(this.User.Id);

            return this.View(cars);
        }

        public HttpResponse Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var user = service.GetUser(this.User.Id);

            if (user.IsMechanic)
            {
                return this.All();
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCarViewModel car)
        {
            var errors = service.AddCar(car, this.User.Id);

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            return this.All();
        }
    }
}

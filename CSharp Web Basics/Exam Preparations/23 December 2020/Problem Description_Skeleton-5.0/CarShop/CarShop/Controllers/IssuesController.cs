namespace CarShop.Controllers
{
    using CarShop.Services.IssuesService;
    using CarShop.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    [Authorize]
    public class IssuesController : Controller
    {
        private readonly IIssueService service;

        public IssuesController(IIssueService _service)
        {
            this.service = _service;
        }

        public HttpResponse CarIssues(string carId)
        {
            var model = service.IssuesModel(carId);

            return this.View(model);
        }

        public HttpResponse Add(string carId)
        {
            var user = service.GetUser(this.User.Id);

            if (user.IsMechanic)
            {
                return this.CarIssues(carId);
            }

            var car = service.GetCar(carId);

            return this.View(car);
        }

        [HttpPost]
        public HttpResponse Add(AddIssueViewModel model)
        {
            var errors = service.AddIssue(model, this.User.Id);

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            return this.CarIssues(model.CarId);
        }

        public HttpResponse Fix(string issueId, string carId)
        {
            var user = service.GetUser(this.User.Id);

            if (!user.IsMechanic)
            {
                return this.CarIssues(carId);
            }

            var errors = service.FixIssue(issueId);

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            return this.CarIssues(carId);
        }

        public HttpResponse Delete(string issueId, string carId)
        {

            var errors = service.DeleteIssue(issueId, carId);

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            return this.CarIssues(carId);
        }
    }
}

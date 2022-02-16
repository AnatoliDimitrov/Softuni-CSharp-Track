namespace Git.Controllers
{
    using Git.Services.RepositoriesService;
    using Git.ViewModels;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    [Authorize]
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService service;

        public RepositoriesController(IRepositoryService _service)
        {
            this.service = _service;
        }

        public HttpResponse All()
        {
            var repos = service.AllRepositories(this.User.Id);

            return this.View(repos);
        }

        public HttpResponse Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryViewModel model)
        {
            var errors = service.CreateRepository(model, this.User.Id);

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            return this.All();
        }
    }
}
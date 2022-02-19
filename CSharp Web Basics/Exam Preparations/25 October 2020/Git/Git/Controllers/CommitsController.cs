namespace Git.Controllers
{
    using Git.Common;
    using Git.Services.CommitsService;
    using Git.ViewModels;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    [Authorize]
    public class CommitsController : Controller
    {
        private readonly ICommitService service;

        public CommitsController(ICommitService _service)
        {
            this.service = _service;
        }

        public HttpResponse Create(string id)
        {
            var repo = this.service.GetRepository(id);

            if (repo == null)
            {
                return this.Error(new string[1] { Constants.MAJOR_ERROR });
            }

            return this.View(repo);
        }

        [HttpPost]
        public HttpResponse Create(AddCommitViewModel model)
        {

            var errors = service.CreateCommit(model, this.User.Id);

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var (errors, commits) = service.AllCommits(this.User.Id);

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            return this.View(commits);
        }

        public HttpResponse Delete(string Id)
        {

            var errors = service.DeleteCommit(Id);

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            return this.All();
        }
    }
}

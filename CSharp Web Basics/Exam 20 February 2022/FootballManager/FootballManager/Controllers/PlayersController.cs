namespace FootballManager.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using FootballManager.Services.PlayersService;
    using FootballManager.ViewModels.Players;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    [Authorize]
    public class PlayersController : Controller
    {
        private readonly IPlayerService service;

        public PlayersController(IPlayerService _service)
        {
            this.service = _service;
        }

        public HttpResponse All()
        {
            var (errors, players) = this.service.AllPlayers();

            if (errors.Any())
            {
                //return this.Error(errors);
                return this.View();
            }

            return this.View(players);
        }

        public HttpResponse Collection()
        {
            var (errors, players) = this.service.MyPlayers(this.User.Id);

            if (errors.Any())
            {
                //return this.Error(errors);
                return this.View();
            }

            return this.View(players);
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddPlayerViewModel model)
        {
            var byteErrors = new List<string>();

            var isByteSpeed = byte.TryParse(model.Speed, out byte speed);
            var isByteEndurance = byte.TryParse(model.Endurance, out byte endurance);

            if (!isByteSpeed || !isByteEndurance)
            {
                byteErrors.Add("Invalid Values");
            }

            if ((speed < 0 || speed > 10) || (endurance < 0 || endurance > 10))
            {
                byteErrors.Add("Invalid Values");
            }

            if(byteErrors.Count > 0)
            {
                return this.Add();
            }

            var errors = service.AddPlayer(model, this.User.Id);

            if (errors.Count > 0)
            {
                return this.Add();
            }

            return this.All();
        }

        public HttpResponse AddToCollection(string playerId)
        {
            var errors = this.service.AddPlayerToCollection(playerId, this.User.Id);

            if (errors.Count > 0)
            {
                return this.All();
            }

            return this.All();
        }

        public HttpResponse RemoveFromCollection(string playerId)
        {
            var errors = this.service.DeletePlayerFromCollection(playerId, this.User.Id);

            if (errors.Count > 0)
            {
                return this.All();
            }

            return this.Collection();
        }
    }
}

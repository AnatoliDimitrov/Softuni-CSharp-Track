namespace SharedTrip.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    
    using SharedTrip.Models.Trips;
    using SharedTrip.Services.TripsService;

    [Authorize]
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(TripService _service)
        {
            this.tripService = _service;
        }
        public HttpResponse All()
        {
            var (errors, trips) = this.tripService.AllTrips();

            if (errors.Any())
            {
                //return this.Error(errors);
                return this.View();
            }

            return this.View(trips);
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateTripForm model)
        {
            var errors = tripService.AddTrip(model);

            if (errors.Any())
            {
                //return this.Error(errors);
                return this.View();
            }

            return this.Redirect("/Home/Index");
        }

        public HttpResponse Details(string tripId)
        {
            var (errors, trip) = this.tripService.TripDetails(tripId);

            if (errors.Count > 0)
            {
                //return this.Error(errors);
                return this.Details(tripId);
            }

            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.tripService.AddUserToTrip(tripId, this.User.Id))
            {
                //return this.Error(errors);
                return this.Details(tripId);
            }

            return this.Redirect("/Trips/All");
        }
    }
}

namespace SharedTrip.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SharedTrip.Common;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Services;

    [Authorize]
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext context;

        public TripsController(IValidator _validator, ApplicationDbContext _context)
        {
            this.validator = _validator;
            this.context = _context;
        }
        public HttpResponse All()
        {
            var trips = this.context
                .Trips
                .Select(x => new ResultModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.M.yyyy г. HH:mm:ss"),
                    Seats = x.Seats,
                })
                .ToList();

            return this.View(trips);
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateTripForm model)
        {
            var errors = validator.ValidateTrip(model);

            if (errors.Any())
            {
                return this.View();
            }


            this.context
                .Trips
                .Add(new Trip()
                {
                    StartPoint = model.StartPoint,
                    EndPoint = model.EndPoint,
                    DepartureTime = DateTime.ParseExact(model.DepartureTime, Constants.DATE_FORMAT, CultureInfo.InvariantCulture),
                    Seats = model.Seats,
                    Description = model.Description,
                    ImagePath = model.ImagePath,
                });


            context.SaveChanges();

            return this.Redirect("/Home/Index");
        }

        public HttpResponse Details(string tripId)
        {
            var trip = this.context
                .Trips
                .Select(x => new ResultModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString(Constants.DATE_FORMAT),
                    Seats = x.Seats,
                    Description = x.Description,
                })
                .FirstOrDefault(t => t.Id == tripId);

            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            var trip = this.context
                .Trips
                .FirstOrDefault(x => x.Id == tripId);

            var user = this.context
                .Users
                .FirstOrDefault(x => x.Id == this.User.Id);

            var userTrip = this.context
                .UsersTrips
                .FirstOrDefault(t => t.TripId == tripId && t.UserId == user.Id);

            if (trip == null || userTrip != null || trip.Seats == 0)
            {
                return this.Details(tripId);
            }

            user.UserTrips.Add(new UserTrip() { UserId = user.Id, TripId = tripId});

            trip.Seats--;

            context.SaveChanges();

            return this.Redirect("/Trips/All");
        }
    }
}

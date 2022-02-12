namespace SharedTrip.Services.TripsService
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using SharedTrip.Common;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Repositories;
    using SharedTrip.Services.ModelsValidatorService;

    public class TripService : ITripService
    {
        private readonly IRepository repository;
        private readonly IModelValidatorService validator;

        public TripService(IModelValidatorService _validator, ApplicationDbContext _context)
        {
            this.repository = new Repository(_context);
            validator = _validator;
        }

        public (ICollection<string>, ICollection<ResultModel>) AllTrips()
        {
            var errors = new List<string>();

            try
            {
                return (errors, this.repository
                .All<Trip>()
                .Select(x => new ResultModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.M.yyyy г. HH:mm:ss"),
                    Seats = x.Seats,
                })
                .ToList());
            }
            catch (Exception)
            {
                errors.Add("Something went wrong. Please try again Later");

                return (errors, null);
            }
        }

        public ICollection<string> ValidateTrip(CreateTripForm model)
        {
            var errors = validator.ValidateModel(model);
            var isInt = int.TryParse(model.Seats, out int result);

            if (!isInt || result < 2 || result > 6)
            {
                errors.Add("Seats must be between 2 and 6 inclusive");
            }

            return errors;
        }

        public ICollection<string> AddTrip(CreateTripForm model)
        {
            var errors = this.ValidateTrip(model);

            try
            {
                this.repository
                    .Add(new Trip()
                    {
                        StartPoint = model.StartPoint,
                        EndPoint = model.EndPoint,
                        DepartureTime = DateTime.ParseExact(model.DepartureTime, Constants.DATE_FORMAT, CultureInfo.InvariantCulture),
                        Seats = int.Parse(model.Seats),
                        Description = model.Description,
                        ImagePath = model.ImagePath,
                    });

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add("Something went wrong. Please try again Later");
            }

            return errors;
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            var trip = this.repository
                .All<Trip>()
                .FirstOrDefault(x => x.Id == tripId);

            var user = this.repository
                .All<User>()
                .FirstOrDefault(x => x.Id == userId);

            var userTrip = this.repository
                .All<UserTrip>()
                .FirstOrDefault(t => t.TripId == tripId && t.UserId == user.Id);

            if (trip == null || userTrip != null || trip.Seats == 0)
            {
                return false;
            }

            user.UserTrips.Add(new UserTrip() { UserId = user.Id, TripId = tripId });

            trip.Seats--;

            repository.SaveChanges();

            return true;
        }

        public (ICollection<string>, ResultModel model) TripDetails(string tripId)
        {
            var errors = new List<string>();

            try
            {
                return (errors, this.repository
                .All<Trip>()
                .Select(x => new ResultModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString(Constants.DATE_FORMAT),
                    Seats = x.Seats,
                    Description = x.Description,
                })
                .FirstOrDefault(t => t.Id == tripId));
            }
            catch (Exception)
            {
                errors.Add("Something went wrong. Please try again Later");

                return (errors, null);
            }
        }
    }
}

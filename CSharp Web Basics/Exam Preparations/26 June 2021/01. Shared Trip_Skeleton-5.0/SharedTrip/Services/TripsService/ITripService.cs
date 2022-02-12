namespace SharedTrip.Services.TripsService
{
    using System.Collections.Generic;

    using SharedTrip.Models.Trips;
    public interface ITripService
    {
        ICollection<string> ValidateTrip(CreateTripForm model);

        ICollection<string> AddTrip(CreateTripForm model);

        bool AddUserToTrip(string tripId, string userId);

        (ICollection<string>, ResultModel model) TripDetails(string tripId);

        (ICollection<string>, ICollection<ResultModel>) AllTrips();
    }
}

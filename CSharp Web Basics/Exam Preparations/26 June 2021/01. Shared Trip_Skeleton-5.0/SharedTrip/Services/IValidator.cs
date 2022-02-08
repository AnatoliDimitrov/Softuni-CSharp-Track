namespace SharedTrip.Services
{
    using System.Collections.Generic;

    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;

    public interface IValidator
    {
        public ICollection<string> ValidateRegistration(UserRegisterForm model);

        public ICollection<string> ValidateTrip(CreateTripForm model);
    }
}

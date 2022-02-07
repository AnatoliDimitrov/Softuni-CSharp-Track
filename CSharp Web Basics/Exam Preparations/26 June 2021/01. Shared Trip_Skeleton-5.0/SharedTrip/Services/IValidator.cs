namespace SharedTrip.Services
{
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        public ICollection<string> ValidateRegistration(UserRegisterForm model);
        public ICollection<string> ValidateTrip(CreateTripForm model);
    }
}

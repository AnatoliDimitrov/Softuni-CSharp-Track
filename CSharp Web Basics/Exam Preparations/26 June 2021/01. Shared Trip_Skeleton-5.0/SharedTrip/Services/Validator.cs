namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;

    using SharedTrip.Common;
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateRegistration(UserRegisterForm model)
        {
            var errors = new List<string>();

            if (model.Username.Length < Constants.LENGTH_5 || model.Username.Length > Constants.LENGTH_20)
            {
                errors.Add("Usename is invalid!");
            }

            if (!Regex.IsMatch(model.Email, Constants.EMAIL_REGEX_PATTERN))
            {
                errors.Add("Email is invalid!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and confirmation are not the same!");
            }

            if (model.Password.Length < Constants.LENGTH_6 || model.Password.Length > Constants.LENGTH_20)
            {
                errors.Add("Password is invalid!");
            }

            return errors;
        }

        public ICollection<string> ValidateTrip(CreateTripForm model)
        {
            var errors = new List<string>();

            var isDate = DateTime.TryParseExact(model.DepartureTime, Constants.DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

            if (!isDate)
            {
                errors.Add("Departure Time is invalid!");
            }

            if (model.Seats < Constants.LENGTH_2 || model.Seats > Constants.LENGTH_6)
            {
                errors.Add("Name is invalid!");
            }

            if (model.Description.Length > 80)
            {
                errors.Add("Price is invalid!");
            }

            return errors;
        }
    }
}

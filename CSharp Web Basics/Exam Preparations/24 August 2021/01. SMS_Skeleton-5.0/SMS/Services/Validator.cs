namespace SMS.Services
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using SMS.Models.Products;
    using SMS.Models.Users;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateRegistration(UserRegisterForm model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add("Usename is invalid!");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                errors.Add("Email is invalid!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and confirmation are not the same!");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add("Password is invalid!");
            }

            return errors;
        }

        public ICollection<string> ValidateProduct(CreateProductForm model)
        {
            var errors = new List<string>();

            if (model.Name.Length < 4 || model.Name.Length > 20)
            {
                errors.Add("Name is invalid!");
            }

            if (model.Price < 0.05m || model.Price > 1000)
            {
                errors.Add("Price is invalid!");
            }

            return errors;
        }
    }
}

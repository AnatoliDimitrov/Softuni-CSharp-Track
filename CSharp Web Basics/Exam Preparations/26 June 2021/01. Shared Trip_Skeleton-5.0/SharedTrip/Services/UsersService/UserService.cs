namespace SharedTrip.Services.UsersService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Models.Users;
    using SharedTrip.Repositories;
    using SharedTrip.Services.ModelsValidatorService;

    public class UserService : IUserService
    {
        private readonly IModelValidatorService validator;
        private readonly IRepository repository;

        public UserService(IModelValidatorService _validator, ApplicationDbContext _context)
        {
            validator = _validator;
            this.repository = new Repository(_context);
        }

        public ICollection<string> ValidateRegistration(UserRegisterForm model)
        {
            return validator.ValidateModel(model);
        }

        public ICollection<string> Register(UserRegisterForm model)
        {
            var errors = this.ValidateRegistration(model);

            if (this.repository.All<User>().Any(u => u.Username == model.Username))
            {
                errors.Add("Username is already taken.");
            }

            if (this.repository.All<User>().Any(u => u.Email == model.Email))
            {
                errors.Add("Email already registered.");
            }

            try
            {
                repository.Add(new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = this.Hash(model.Password),
                });

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add("Something went wrong. Please try again later.");
            }

            return errors;
        }

        public string Login(LoginUserForm model)
        {
            var hashedPassword = this.Hash(model.Password);

            var userId = this.repository
                .All<User>()
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        public string Hash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

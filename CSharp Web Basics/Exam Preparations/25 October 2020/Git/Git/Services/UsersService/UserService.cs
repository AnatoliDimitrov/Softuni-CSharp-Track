namespace Git.Services.UsersService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using Git.Common;
    using Git.Data;
    using Git.Models;
    using Git.Repositories;
    using Git.Services.ModelsValidatorService;
    using Git.ViewModels;

    public class UserService : IUserService
    {
        private readonly IModelValidatorService validator;
        private readonly IRepository repository;

        public UserService(IModelValidatorService _validator, ApplicationDbContext _context)
        {
            validator = _validator;
            this.repository = new Repositories.Repository(_context);
        }

        public ICollection<string> Register(UserRegisterForm model)
        {
            var errors = validator.ValidateModel(model);

            if (this.repository.All<User>().Any(u => u.Username == model.Username))
            {
                errors.Add("Username is already taken.");
            }

            if (this.repository.All<User>().Any(u => u.Email == model.Email))
            {
                errors.Add("Email already registered.");
            }

            if (errors.Count > 0)
            {
                return errors;
            }

            try
            {
                repository.Add(new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = this.Hash(model.Password),
                }); ;

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }

        public (string id, ICollection<string> errors) Login(LoginUserForm model)
        {
            var errors = new List<string>();

            var hashedPassword = this.Hash(model.Password);

            try
            {
                var userId = this.repository
                    .All<User>()
                    .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                return (userId, errors);
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return (null, errors);
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

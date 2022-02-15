using CarShop.Common.Constants;
using CarShop.Data;
using CarShop.Models;
using CarShop.Repositories;
using CarShop.Services.ModelsValidatorService;
using CarShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services.IssuesService
{
    public class IssueService : IIssueService
    {
        private readonly IRepository repository;
        private readonly IModelValidatorService validator;

        public IssueService(ApplicationDbContext _context, IModelValidatorService _validator)
        {
            this.repository = new Repository(_context);
            validator = _validator;
        }

        public User GetUser(string userId)
        {
            return repository.All<User>()
                .FirstOrDefault(u => u.Id == userId);
        }

        public Issue GetIssue(string issueId)
        {
            return repository.All<Issue>()
                .FirstOrDefault(u => u.Id == issueId);
        }

        public Car GetCar(string carId)
        {
            var car = repository.All<Car>()
                .FirstOrDefault(c => c.Id == carId);

            return car;
        }

        public CarIssuesViewModel IssuesModel(string carId)
        {
            var car = this.GetCar(carId);

            var issues = repository.All<Issue>()
                .Where(i => i.CarId == carId)
                .ToList();

            return new CarIssuesViewModel()
            {
                CarId = carId,
                Model = car.Model,
                Year = car.Year.ToString(),
                Issues = issues,
            };
        }

        public ICollection<string> AddIssue(AddIssueViewModel issue, string userId)
        {
            var errors = validator.ValidateModel(issue);

            if (errors.Count > 0)
            {
                return errors;
            }

            try
            {
                this.repository
                     .Add(new Issue()
                     {
                         Description = issue.Description,
                         CarId = issue.CarId,
                     });

                repository.SaveChanges();
            }
            catch (System.Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }

        public ICollection<string> FixIssue(string issueId)
        {
            var errors = new List<string>();

            var issue = this.GetIssue(issueId);

            try
            {
                issue.IsFixed = true;

                repository.SaveChanges();
            }
            catch (System.Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }

        public ICollection<string> DeleteIssue(string issueId, string carId)
        {
            var errors = new List<string>();

            var car = this.GetCar(carId);

            var issue = this.GetIssue(issueId);


            try
            {
                car.Issues.Remove(issue);

                repository.All<Issue>()
                    .ToList()
                    .Remove(issue);


                repository.SaveChanges();
            }
            catch (System.Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }
    }
}

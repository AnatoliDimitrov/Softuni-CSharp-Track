namespace CarShop.Services.CarsService
{
    using CarShop.Common.Constants;
    using CarShop.Data;
    using CarShop.Models;
    using CarShop.Repositories;
    using CarShop.Services.ModelsValidatorService;
    using CarShop.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class CarService : ICarService
    {
        private readonly IRepository repository;
        private readonly IModelValidatorService validator;

        public CarService(ApplicationDbContext _context, IModelValidatorService _validator)
        {
            this.repository = new Repository(_context);
            validator = _validator;
        }

        public User GetUser(string userId)
        {
            return repository.All<User>()
                .FirstOrDefault(u => u.Id == userId);
        }

        public ICollection<CarsAllVieModel> AllCars(string userId)
        {
            var user = repository.All<User>()
                .FirstOrDefault(u => u.Id == userId);

            if (user.IsMechanic)
            {
                return repository.All<Car>()
                    .Select(c => new CarsAllVieModel()
                    {
                        Id = c.Id,
                        Model = c.Model,
                        PlateNumber = c.PlateNumber,
                        PictureUrl = c.PictureUrl,
                        Fixed = c.Issues.Count(i => i.IsFixed),
                        UnFixed = c.Issues.Count(i => i.IsFixed == false),
                    })
                    .ToList();
            }

            return repository.All<Car>()
                .Where(c => c.OwnerId == userId)
                .Select(c => new CarsAllVieModel()
                {
                    Id = c.Id,
                    Model = c.Model,
                    PlateNumber = c.PlateNumber,
                    PictureUrl = c.PictureUrl,
                    Fixed = c.Issues.Count(i => i.IsFixed == true),
                    UnFixed = c.Issues.Count(i => i.IsFixed == false),
                })
                .ToList();
        }

        public ICollection<string> AddCar(AddCarViewModel car, string userId)
        {
            var errors = validator.ValidateModel(car);

            var isYear = int.TryParse(car.Year, out int year);

            if (errors.Count > 0)
            {
                return errors;
            }

            if (!isYear)
            {
                errors.Add("Year is not valid");
                return errors;
            }

            try
            {
                this.repository
                     .Add(new Car()
                     {
                         Model = car.Model,
                         Year = year,
                         PictureUrl = car.Image,
                         PlateNumber=car.PlateNumber,
                         OwnerId = userId,
                     });

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

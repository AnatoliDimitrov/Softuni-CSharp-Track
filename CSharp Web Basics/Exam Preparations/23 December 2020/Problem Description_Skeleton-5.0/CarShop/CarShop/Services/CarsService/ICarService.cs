namespace CarShop.Services.CarsService
{
    using CarShop.Models;
    using CarShop.ViewModels;
    using System.Collections.Generic;

    public interface ICarService
    {
        public ICollection<CarsAllVieModel> AllCars(string userId);

        User GetUser(string userId);

        ICollection<string> AddCar(AddCarViewModel car, string userId);
    }
}

namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Text;
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>(capacity);
            this.capacity = capacity;
        }

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        public int Count
        {
            get { return cars.Count; }
        }


        public string AddCar(Car car)
        {
            Car tempCar = cars
                .Find(c => c.RegistrationNumber == car.RegistrationNumber);
            if (tempCar != null)
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            Car currentCar = cars
                .Find(c => c.RegistrationNumber == registrationNumber);

            if (currentCar == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(currentCar);
                return $"Successfully removed {currentCar.RegistrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car currentCar = cars
                .Find(c => c.RegistrationNumber == registrationNumber);

            return currentCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                Car currentCar = cars
                    .Find(c => c.RegistrationNumber == registrationNumbers[i]);

                if (currentCar != null)
                {
                    cars.Remove(currentCar);
                }
            }
        }
    }
}

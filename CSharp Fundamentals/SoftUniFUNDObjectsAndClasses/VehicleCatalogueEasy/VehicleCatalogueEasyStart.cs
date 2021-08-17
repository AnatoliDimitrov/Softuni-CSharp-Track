using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogueEasy
{
    class VehicleCatalogueEasyStart
    {
        static void Main()
        {
            string input = "";

            Catalogue catalogue = new Catalogue();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input.Split("/");
                string type = data[0];
                string brand = data[1];
                string model = data[2];
                double info = double.Parse(data[3]);

                if (type == "Car")
                {
                    catalogue.CarList.Add(new Car(brand, model, info));
                }
                else
                {
                    catalogue.TruckList.Add(new Truck(brand, model, info));
                }
            }

            List<Car> carResult = catalogue.CarList.OrderBy(c => c.Brand).ToList();
            List<Truck> truckResult = catalogue.TruckList.OrderBy(t => t.Brand).ToList();

            if (carResult.Count > 0)
            {
                Console.WriteLine("Cars:");
            }
            foreach (var car in carResult)
            {
                Console.WriteLine(car);
            }
            if (truckResult.Count > 0)
            {
                Console.WriteLine("Trucks:");
            }
            foreach (var truck in truckResult)
            {
                Console.WriteLine(truck);
            }
        }
    }
}

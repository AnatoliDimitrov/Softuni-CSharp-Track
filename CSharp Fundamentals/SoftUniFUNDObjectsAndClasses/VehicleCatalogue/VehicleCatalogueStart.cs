using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class VehicleCatalogueStart
    {
        static void Main()
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ");
                string type = data[0];
                string model = data[1];
                string color = data[2];
                double power = double.Parse(data[3]);

                catalogue.Add(new Vehicle(type, model, color, power));
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle temp = catalogue.Find(v => v.Model == input);
                Console.WriteLine(temp.ToString());
            }



            List<double> trucksPowers = catalogue
                .Where(t => t.Type == "Truck")
                .Select(a => a.HorsePower)
                .ToList();

            List<double> carsPowers = catalogue
                .Where(t => t.Type == "Car")
                .Select(a => a.HorsePower)
                .ToList();
            double carAverage = 0;
            double truckAverage = 0;

            if (trucksPowers.Count > 0)
            {
                truckAverage = trucksPowers.Average();
            }
            if (carsPowers.Count>0)
            {
                carAverage = carsPowers.Average();
            }
            

            Console.WriteLine($"Cars have average horsepower of: {carAverage:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {truckAverage:f2}.");
        }
    }
}


namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            string input = "";

            List<Tire[]> tiresCollections = new List<Tire[]>(); 

            while ((input = Console.ReadLine()) != "No more tires")
            {
                var tiresInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] newTires = new Tire[4];

                for (int i = 0; i < tiresInfo.Length; i += 2)
                {
                    newTires[i / 2] = new Tire(int.Parse(tiresInfo[i]), double.Parse(tiresInfo[i + 1]));
                }
                tiresCollections.Add(newTires);
            }

            var engines = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                var inputInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                engines.Add(new Engine(int.Parse(inputInfo[0]), double.Parse(inputInfo[1])));
            }

            var cars = new List<Car>();

            while ((input = Console.ReadLine()) != "Show special")
            {
                var inputInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = inputInfo[0];
                string model = inputInfo[1];
                int year = int.Parse(inputInfo[2]);
                double fuelQuantity = double.Parse(inputInfo[3]);
                double fuelConsumption = double.Parse(inputInfo[4]);
                Engine engine = engines[int.Parse(inputInfo[5])];
                Tire[] tires = tiresCollections[int.Parse(inputInfo[6])];

                cars.Add(new Car(make, model, year,fuelQuantity, fuelConsumption, engine, tires));
            }

            for (int i = 0; i < cars.Count; i++)
            {
                Car currentCar = cars[i];

                double tiresPressure = currentCar
                    .Tires
                    .Sum(t => t.Pressure);

                if (currentCar.Year >= 2017 && currentCar.Engine.HorsePower > 330 && (tiresPressure >= 9 && tiresPressure <= 10))
                {
                    currentCar.Drive(20);
                    Console.WriteLine(currentCar.WhoAmI()); 
                }
            }
        }
    }
}

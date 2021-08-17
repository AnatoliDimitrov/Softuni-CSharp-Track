using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carQuantity = double.Parse(carInfo[1]);
            double carConsumtion = double.Parse(carInfo[2]);
            double carCapacity = double.Parse(carInfo[3]);

            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckQuantity = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            double truckCapacity = double.Parse(truckInfo[3]);

            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busQuantity = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busCapacity = double.Parse(busInfo[3]);

            var car = new Car(carQuantity, carConsumtion, carCapacity);
            var truck = new Truck(truckQuantity, truckConsumption, truckCapacity);
            var bus = new Bus(busQuantity, busConsumption, busCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdInfo[0];
                string vehicle = cmdInfo[1];
                double num = double.Parse(cmdInfo[2]);

                if (command == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(num));
                    }
                    else if(vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(num));
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(num));
                    }
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(num);
                        }
                        else if(vehicle == "Truck")
                        {
                            truck.Refuel(num);
                        }
                        else
                        {
                            bus.Refuel(num);
                        }
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                else if (command == "DriveEmpty")
                {
                    Console.WriteLine(bus.DriveEmpty(num));
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}

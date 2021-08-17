using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class ParkingLotStart
    {
        static void Main()
        {
            HashSet<string> parkingLot = new HashSet<string>();

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] carInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = carInfo[0];
                string plate = carInfo[1];

                if (direction == "IN")
                {
                    parkingLot.Add(plate);
                }
                else if (direction == "OUT")
                {
                    parkingLot.Remove(plate);
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var plateNumber in parkingLot)
                {
                    Console.WriteLine(plateNumber);
                }
            }
        }
    }
}

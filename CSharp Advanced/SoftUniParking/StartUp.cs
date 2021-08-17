namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EГ8787MN");
            var car3 = new Car("WV", "Fabia", 65, "CТ1856BG");
            var car4 = new Car("Audi", "A3", 110, "EМ8787MN");
            var car5 = new Car("Skoda", "Fabia", 65, "CР1856BG");
            var car6 = new Car("Audi", "A3", 110, "EЦ8787MN");

            Console.WriteLine(car.ToString());
            //Make: Skoda
            //Model: Fabia
            //HorsePower: 65
            //RegistrationNumber: CC1856BG

            var parking = new Parking(5);
            Console.WriteLine(parking.AddCar(car));
            //Successfully added new car Skoda CC1856BG

            Console.WriteLine(parking.RemoveCar("EB8787MN"));

            Console.WriteLine(parking.AddCar(car));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car2));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.AddCar(car3));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car4));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.AddCar(car5));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car6));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.AddCar(car));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car2));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());
            //Make: Audi
            //Model: A3
            //HorsePower: 110
            //RegistrationNumber: EB8787MN

            Console.WriteLine(parking.RemoveCar("EB8787MN"));
            //Successfullyremoved EB8787MN

            parking.RemoveSetOfRegistrationNumber(new List<string>() { "EB8787MN", "CC1856BG" });

            Console.WriteLine(parking.Count); //1

        }
    }
}

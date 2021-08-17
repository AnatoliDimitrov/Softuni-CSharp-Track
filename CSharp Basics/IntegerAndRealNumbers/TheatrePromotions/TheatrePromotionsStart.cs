using System;

namespace TheatrePromotions
{
    class TheatrePromotionsStart
    {
        static void Main()
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int[,] prices = new int[,] {
                {12, 18, 12},
                {15, 20, 15},
                {5, 12, 10}
            };

            int dayIndex = 0;
            int ageIndex;

            switch (day)
            {
                case "Weekend":
                    dayIndex = 1;
                    break;
                case "Holiday":
                    dayIndex = 2;
                    break;
            }
            if (age >= 0 && age <= 18)
            {
                ageIndex = 0;
            }
            else if (age > 18 && age <= 64)
            {
                ageIndex = 1;
            }
            else if (age > 64 && age <= 122)
            {
                ageIndex = 2;
            }
            else
            {
                Console.WriteLine("Error!");
                return;
            }

            Console.WriteLine("{0}$", prices[dayIndex, ageIndex]);
        }
    }
}

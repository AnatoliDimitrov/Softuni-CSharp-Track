namespace Vacation
{
    using System;
    class VacationStart
    {
        static void Main()
        {
            int groupCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            double totalPrice = 0;

            double[,] prices = { 
                {8.45, 9.80, 10.46 },
                {10.90, 15.60, 16 },
                {15, 20, 22.5 } 
            };

            int groupTypeInt = 0;
            
            if (groupType == "Business")
            {
                groupTypeInt = 1;
            }
            else if (groupType == "Regular")
            {
                groupTypeInt = 2;
            }

            int dayInt = 0;

            if (day == "Saturday")
            {
                dayInt = 1;
            }
            else if (day == "Sunday")
            {
                dayInt = 2;
            }

            double priceForOne = prices[groupTypeInt,dayInt];

            totalPrice = groupCount * priceForOne;
            if (groupType == "Students")
            {
                if (groupCount >= 30)
                {
                    totalPrice *= 0.85;
                }
            }
            else if (groupType == "Regular")
            {
                if (groupCount >= 10 && groupCount <= 20)
                {
                    totalPrice *= 0.95;
                }
            }
            else
            {
                if (groupCount >= 100)
                {
                    totalPrice = (groupCount - 10) * priceForOne;
                }
            }

            Console.WriteLine("Total price: {0:0.00}", totalPrice);
        }
    }
}

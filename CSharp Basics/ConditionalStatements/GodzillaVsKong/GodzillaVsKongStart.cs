namespace GodzillaVsKong
{
    using System;
    class GodzillaVsKongStart
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            double statists = double.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());

            double decorPrice = budget * 0.1;
            double statitstsClothing = statists * clothingPrice;

            if (statists > 150)
            {
                statitstsClothing *= 0.9;
            }

            double total = statitstsClothing + decorPrice;

            if (total <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine("Wingard starts filming with {0:0.00} leva left.", budget - total);
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine("Wingard needs {0:0.00} leva more.", total - budget);
            }
        }
    }
}

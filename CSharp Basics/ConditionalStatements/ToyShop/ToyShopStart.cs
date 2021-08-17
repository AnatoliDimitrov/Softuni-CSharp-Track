namespace ToyShop
{
    using System;
    class ToyShopStart
    {
        static void Main()
        {
            double holydayPrice = double.Parse(Console.ReadLine());
            double puzzles = double.Parse(Console.ReadLine());
            double talkingDolls = double.Parse(Console.ReadLine());
            double teddyBears = double.Parse(Console.ReadLine());
            double minions = double.Parse(Console.ReadLine());
            double trucks = double.Parse(Console.ReadLine());

            double puzzlessPrice = puzzles * 2.6;
            double talkingDollssPrice = talkingDolls * 3.0;
            double teddyBearssPrice = teddyBears * 4.1;
            double minionssPrice = minions * 8.2;
            double truckssPrice = trucks * 2.0;

            double allToys = puzzles + talkingDolls + teddyBears + minions + trucks;

            double total = puzzlessPrice + talkingDollssPrice + teddyBearssPrice + minionssPrice + truckssPrice;

            if (allToys >= 50)
            {
                total *= 0.75;
            }

            total *= 0.90;

            if (total >= holydayPrice)
            {
                Console.WriteLine("Yes! {0:0.00} lv left.", total - holydayPrice);
            }
            else if (total < holydayPrice)
            {
                Console.WriteLine("Not enough money! {0:0.00} lv needed.", holydayPrice - total);
            }
        }
    }
}

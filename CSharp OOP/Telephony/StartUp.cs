using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] sites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        stationaryPhone.Call(number);
                    }
                    else
                    {
                        smartphone.Call(number);
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            foreach (var site in sites)
            {
                try
                {
                    smartphone.Browse(site);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}

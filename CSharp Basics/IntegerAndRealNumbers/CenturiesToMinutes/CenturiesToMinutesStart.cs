using System;

namespace CenturiesToMinutes
{
    class CenturiesToMinutesStart
    {
        static void Main()
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            decimal days = years * 365.2422m;
            int hours = (int)days * 24;
            decimal minutes = hours * 60;

            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes", centuries, years, (int)days, hours, minutes);
        }
    }
}

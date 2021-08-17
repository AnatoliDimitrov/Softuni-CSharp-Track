using System;
using System.Globalization;

namespace DayOfWeek
{
    class DayOfWeekStart
    {
        static void Main()
        {
            string input = Console.ReadLine();

            DateTime day = DateTime.ParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(day.DayOfWeek);
        }
    }
}

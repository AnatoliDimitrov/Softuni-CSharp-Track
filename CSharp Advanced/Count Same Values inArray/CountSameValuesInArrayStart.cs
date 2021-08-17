using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class CountSameValuesInArrayStart
    {
        static void Main()
        {
            double[] values = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> counters = new Dictionary<double, int>();

            for (int i = 0; i < values.Count(); i++)
            {
                if (!counters.ContainsKey(values[i]))
                {
                    counters.Add(values[i], 0);
                }

                counters[values[i]]++;
            }

            foreach (var (key, value) in counters)
            {
                Console.WriteLine($"{key} - {value} times");
            }
        }
    }
}

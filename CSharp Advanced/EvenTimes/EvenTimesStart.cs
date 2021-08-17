using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class EvenTimesStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> counters = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!counters.ContainsKey(input))
                {
                    counters[input] = 0;
                }

                counters[input]++;
            }

            foreach (var (key, value) in counters)
            {
                if (value % 2 == 0)
                {
                    Console.WriteLine(key);
                    break;
                }
            }
        }
    }
}

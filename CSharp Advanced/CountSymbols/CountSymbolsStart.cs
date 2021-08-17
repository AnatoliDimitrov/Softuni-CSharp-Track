using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class CountSymbolsStart
    {
        static void Main()
        {
            char[] input = Console.ReadLine()
                .ToCharArray();

            SortedDictionary<char, int> counters = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!counters.ContainsKey(input[i]))
                {
                    counters[input[i]] = 0;
                }

                counters[input[i]]++;
            }

            foreach (var (key, value) in counters)
            {
                Console.WriteLine($"{key}: {value} time/s");
            }
        }
    }
}

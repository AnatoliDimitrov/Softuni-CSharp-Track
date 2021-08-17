using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class PeriodicTableStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> table = new SortedSet<string>();
            
            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < elements.Length; j++)
                {
                    table.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", table));
        }
    }
}

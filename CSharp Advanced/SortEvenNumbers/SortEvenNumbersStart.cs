using System;
using System.Linq;

namespace SortEvenNumbers
{
    class SortEvenNumbersStart
    {
        static void Main()
        {
            var nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToList();

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}

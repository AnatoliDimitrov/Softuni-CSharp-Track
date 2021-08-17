using System;
using System.Linq;

namespace SumNumbers
{
    class SumNumbersStart
    {
        static void Main()
        {
            var nums = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            Console.WriteLine(nums.Count);
            Console.WriteLine(nums.Sum());
        }
    }
}

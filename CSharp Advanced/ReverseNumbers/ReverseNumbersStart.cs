using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbers
{
    class ReverseNumbersStart
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> reversed = new Stack<int>(nums);

            Console.WriteLine(string.Join(" ", reversed));
        }
    }
}

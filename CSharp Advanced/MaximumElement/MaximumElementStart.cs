using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class MaximumElementStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] queries = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int query = queries[0];

                if (query == 1)
                {
                    nums.Push(queries[1]);
                }
                else if (query == 2)
                {
                    nums.Pop();
                }
                else if (query == 3)
                {
                    Console.WriteLine(nums.Max());
                }

            }
        }
    }
}

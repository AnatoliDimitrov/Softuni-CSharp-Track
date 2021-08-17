using System;
using System.Collections.Generic;

namespace SetsOfElements
{
    class SetsOfElementsStart
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            HashSet<double> nNumbers = new HashSet<double>();
            HashSet<double> mNumbers = new HashSet<double>();

            for (int i = 0; i < n; i++)
            {
                nNumbers.Add(double.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                mNumbers.Add(double.Parse(Console.ReadLine()));
            }

            HashSet<double> result = new HashSet<double>();

            if (nNumbers.Count <= mNumbers.Count)
            {
                FindUniques(nNumbers, mNumbers, result);
            }
            else
            {
                FindUniques(mNumbers, nNumbers, result);
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static void FindUniques(HashSet<double> smaller, HashSet<double> bigger, HashSet<double> result)
        {
            foreach (var num in smaller)
            {
                if (bigger.Contains(num))
                {
                    result.Add(num);
                }
            }
        }
    }
}

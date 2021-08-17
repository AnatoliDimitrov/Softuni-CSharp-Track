using System;
using System.Linq;

namespace RecursiveArraySum
{
    class RecursiveArraySumStart
    {
        static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(arr));
        }

        private static int Sum(int[] arr, int index = 0)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + Sum(arr, index + 1);
        }
    }
}

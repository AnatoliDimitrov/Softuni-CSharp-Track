using System;
using System.Linq;

namespace SumMatrixColumns
{
    class SumMatrixColumnsStart
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < sizes[0]; i++)
            {
                int[] current = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < sizes[1]; j++)
                {
                    matrix[i, j] = current[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int currentSum = 0;

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    currentSum += matrix[j, i];
                }
                Console.WriteLine(currentSum);
            }
        }
    }
}

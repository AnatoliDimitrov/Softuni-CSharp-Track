using System;
using System.Linq;

namespace SumMatrixElements
{
    class SumMatrixElementsStart
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            int sum = 0;

            for (int i = 0; i < sizes[0]; i++)
            {
                int[] current = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < sizes[1]; j++)
                {
                    matrix[i, j] = current[j];
                    sum += current[j];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}

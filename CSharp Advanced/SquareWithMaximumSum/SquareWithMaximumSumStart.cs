using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class SquareWithMaximumSumStart
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] current = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = current[j];
                }
            }

            int biggestSum = int.MinValue;
            int row = 0;
            int col = 0;


            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1]; 
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        row = i;
                        col = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[row, col]} {matrix[row, col + 1]}");
            Console.WriteLine($"{matrix[row + 1, col]} {matrix[row + 1, col + 1]}");
            Console.WriteLine(biggestSum);
        }
    }
}

using System;
using System.Linq;

namespace MaximalSum
{
    class MaximalSumStart
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0],sizes[1]];

            for (int i = 0; i < sizes[0]; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < currentRow.Length; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int biggestSum = int.MinValue;
            int row = -1;
            int col = -1;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {

                    int currentSum = FindBiggestSum(i, j, matrix);
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        row = i;
                        col = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");
            Print(row, col, matrix);
        }

        static void Print(int row, int col, int[,] matrix)
        {
            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    Console.Write(matrix[i, j] + " "); 
                }
                Console.WriteLine();
            }
        }
        static int FindBiggestSum(int row, int col, int[,]matrix)
        {
            int sum = 0;

            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }
    }
}

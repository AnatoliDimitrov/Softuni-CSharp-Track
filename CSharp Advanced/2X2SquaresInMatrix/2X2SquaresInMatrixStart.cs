using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    class _2X2SquaresInMatrixStart
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int counter = 0;

            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int i = 0; i < sizes[0]; i++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < currentRow.Length; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (EqualChars(i, j, matrix))
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }

        static bool EqualChars(int row, int col, string[,]matrix)
        {
            return matrix[row, col] == matrix[row, col + 1] &&
                matrix[row, col] == matrix[row + 1, col] &&
                matrix[row, col] == matrix[row + 1, col + 1];
        }
    }
}

using System;
using System.Linq;

namespace MatrixShuffling
{
    class MatrixShufflingStart
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int i = 0; i < sizes[0]; i++)
            {
                string[] currentInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < currentInput.Length; j++)
                {
                    matrix[i, j] = currentInput[j];
                }
            }

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] instructions = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (instructions.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (instructions[0] == "swap")
                {
                    int row1 = int.Parse(instructions[1]);
                    int col1 = int.Parse(instructions[2]);
                    int row2 = int.Parse(instructions[3]);
                    int col2 = int.Parse(instructions[4]);

                    if (ValidateIndexes(row1, row2, col1, col2, sizes[0], sizes[1]))
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        Print(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static bool ValidateIndexes(int row1, int row2, int col1, int col2, int rowsLength, int colsLength)
        {
            return (row1 >= 0 && row1 < rowsLength) &&
                (row2 >= 0 && row2 < rowsLength) &&
                (col1 >= 0 && col1 < colsLength) &&
                (col2 >= 0 && col2 < colsLength);
        }

        static void Print(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

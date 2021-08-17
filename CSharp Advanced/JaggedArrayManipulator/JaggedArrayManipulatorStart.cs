using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class JaggedArrayManipulatorStart
    {
        static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            decimal[][] jaggedArray = new decimal[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                jaggedArray[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    Multiply(jaggedArray, i);
                }
                else
                {
                    Divide(jaggedArray, i);
                    Divide(jaggedArray, i + 1);
                }
            }

            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] instructions = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                string command = instructions[0];
                int row = int.Parse(instructions[1]);
                int col = int.Parse(instructions[2]);
                int value = int.Parse(instructions[3]);

                if (row >= 0 && row < jaggedArray.Length)
                {
                    if (col >= 0 && col < jaggedArray[row].Length)
                    {
                        if (command == "Add")
                        {
                            jaggedArray[row][col] += value;
                        }
                        else if (command == "Subtract")
                        {
                            jaggedArray[row][col] -= value;
                        }
                    }
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }

        static void Multiply(decimal[][] matrix, int row)
        {
            for (int i = 0; i < matrix[row].Length; i++)
            {
                matrix[row][i] *= 2;
                matrix[row + 1][i] *= 2;
            }
        }

        static void Divide(decimal[][] matrix, int row)
        {
            for (int i = 0; i < matrix[row].Length; i++)
            {
                matrix[row][i] /= 2;
            }
        }
    }
}

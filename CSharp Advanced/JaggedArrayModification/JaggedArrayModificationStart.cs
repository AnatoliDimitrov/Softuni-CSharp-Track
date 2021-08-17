using System;
using System.Linq;

namespace JaggedArrayModification
{
    class JaggedArrayModificationStart
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] instructions = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = instructions[0];
                int row = int.Parse(instructions[1]);
                int col = int.Parse(instructions[2]);
                int value = int.Parse(instructions[3]);

                if (!ValidateCoordinates(row, col, rows))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    matrix[row][col] += value;
                }
                else
                {
                    matrix[row][col] -= value;
                }
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static bool ValidateCoordinates(int row, int col, int rows)
        {
            return row >= 0 && row < rows && col >= 0 && col < rows;
        }
    }
}

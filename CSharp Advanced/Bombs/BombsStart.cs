using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class BombsStart
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] field = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < currentRow.Length; j++)
                {
                    field[i, j] = currentRow[j];
                }
            }

            string[] rawPositions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<int[]> bombsPositions = new List<int[]>();

            for (int i = 0; i < rawPositions.Length; i++)
            {
                bombsPositions.Add(rawPositions[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            }

            foreach (var item in bombsPositions)
            {
                int value = field[item[0], item[1]];
                if (value > 0)
                {
                    Explode(field, item[0], item[1], value);
                    field[item[0], item[1]] = 0;
                }
            }

            int aliveCellsCounter = 0;
            int sumOfAlive = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] > 0)
                    {
                        aliveCellsCounter++;
                        sumOfAlive += field[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCounter}");
            Console.WriteLine($"Sum: {sumOfAlive}");

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Explode(int[,] field, int row, int col, int value)
        {
            int[][] moves = new int[8][];

            moves[0] = new int[] { row - 1, col - 1 };
            moves[1] = new int[] { row - 1, col };
            moves[2] = new int[] { row - 1, col + 1 };
            moves[3] = new int[] { row, col - 1 };
            moves[4] = new int[] { row, col + 1 };
            moves[5] = new int[] { row + 1, col - 1 };
            moves[6] = new int[] { row + 1, col };
            moves[7] = new int[] { row + 1, col + 1 };

            for (int i = 0; i < moves.Length; i++)
            {
                int movedRow = moves[i][0];
                int movedCol = moves[i][1];

                if ((movedRow >= 0 && movedRow < field.GetLength(0)) && (movedCol >= 0 && movedCol < field.GetLength(1)))
                {
                    if (field[movedRow, movedCol] > 0)
                    {
                        field[movedRow, movedCol] -= value;
                    }
                }
            }
        }
    }
}

using System;
using System.Linq;

namespace Miner
{
    class MinerStart
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[,] field = new string[size, size];

            int allCoals = 0;

            int minerRow = 0;
            int minerCol = 0;

            for (int i = 0; i < size; i++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < currentRow.Length; j++)
                {
                    field[i, j] = currentRow[j];
                    if (currentRow[j] == "c")
                    {
                        allCoals++;
                    }
                    else if (currentRow[j] == "s")
                    {
                        minerRow = i;
                        minerCol = j;
                    }
                }
            }

            int collectedCoals = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];
                if (command == "up")
                {
                    if (CheckBounderies(field, minerRow - 1, minerCol))
                    {
                        field[minerRow, minerCol] = "*";
                        string newCell = field[minerRow - 1, minerCol];
                        field[minerRow - 1, minerCol] = "s";
                        minerRow -= 1; 

                        if (newCell == "c")
                        {
                            collectedCoals++;
                        }
                        else if (newCell == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }

                }
                else if (command == "down")
                {
                    if (CheckBounderies(field, minerRow + 1, minerCol))
                    {
                        field[minerRow, minerCol] = "*";
                        string newCell = field[minerRow + 1, minerCol];
                        field[minerRow + 1, minerCol] = "s";
                        minerRow += 1;

                        if (newCell == "c")
                        {
                            collectedCoals++;
                        }
                        else if (newCell == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (CheckBounderies(field, minerRow, minerCol - 1))
                    {
                        field[minerRow, minerCol] = "*";
                        string newCell = field[minerRow, minerCol - 1];
                        field[minerRow, minerCol - 1] = "s";
                        minerCol -= 1;

                        if (newCell == "c")
                        {
                            collectedCoals++;
                        }
                        else if (newCell == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (CheckBounderies(field, minerRow, minerCol + 1))
                    {
                        field[minerRow, minerCol] = "*";
                        string newCell = field[minerRow, minerCol + 1];
                        field[minerRow, minerCol + 1] = "s";
                        minerCol += 1;

                        if (newCell == "c")
                        {
                            collectedCoals++;
                        }
                        else if (newCell == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }

                if (collectedCoals == allCoals)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
            }

            Console.WriteLine($"{allCoals - collectedCoals} coals left. ({minerRow}, {minerCol})");
        }

        static bool CheckBounderies(string[,] field, int row, int col)
        {
            return (row >= 0 && row < field.GetLength(0)) && (col >= 0 && col < field.GetLength(1));
        }
    }
}

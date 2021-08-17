using System;

namespace TronRacers
{
    class TronRacersStart
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            int firstPlayerRow = -1;
            int firstPlayerCol = -1;

            int secondPlayerRow = -1;
            int secondPlayerCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                     .ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j].ToString();

                    if (matrix[i, j] == "f")
                    {
                        firstPlayerRow = i;
                        firstPlayerCol = j;
                    }
                    else if (matrix[i, j] == "s")
                    {
                        secondPlayerRow = i;
                        secondPlayerCol = j;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string commandFirst = commands[0];
                string commandSecond = commands[1];

                string cellToMoveFirstPlayer = Move(matrix, commandFirst, ref firstPlayerRow, ref firstPlayerCol);

                if (cellToMoveFirstPlayer == "s")
                {
                    matrix[firstPlayerRow, firstPlayerCol] = "x";
                    break;
                }
                else
                {
                    matrix[firstPlayerRow, firstPlayerCol] = "f";
                }

                string cellToMoveSecondPlayer = Move(matrix, commandSecond, ref secondPlayerRow, ref secondPlayerCol);

                if (cellToMoveSecondPlayer == "f")
                {
                    matrix[secondPlayerRow, secondPlayerCol] = "x";
                    break;
                }
                else
                {
                    matrix[secondPlayerRow, secondPlayerCol] = "s";
                }
            }

            Print(matrix);
        }

        static void Print(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static string Move(string[,] matrix, string command, ref int row, ref int col)
        {
            int len = matrix.GetLength(0);

            if (command == "up")
            {
                row--;

                if (row < 0)
                {
                    row = len - 1;
                }
            }
            else if (command == "down")
            {
                row++;

                if (row == len)
                {
                    row = 0;
                }
            }
            else if (command == "left")
            {
                col--;
                if (col < 0)
                {
                    col = len - 1;
                }
            }
            else if (command == "right")
            {
                col++;

                if (col == len)
                {
                    col = 0;
                }
            }

            return matrix[row, col];
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem02
{
    class Entry
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            int snakeRow = -1;
            int snakeCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (line[j].ToString() == "S")
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }

                    matrix[i, j] = line[j].ToString();
                }
            }

            int foodEaten = 0;

            string command = Console.ReadLine();

            while (true)
            {

                matrix[snakeRow, snakeCol] = ".";

                if (command == "up")
                {
                    snakeRow--;
                }
                else if (command == "down")
                {
                    snakeRow++;
                }
                else if (command == "left")
                {
                    snakeCol--;
                }
                else if (command == "right")
                {
                    snakeCol++;
                }

                if (CheckBounderies(matrix, snakeRow, snakeCol))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (foodEaten == 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
                else if (matrix[snakeRow, snakeCol] == "*")
                {
                    foodEaten++;
                    matrix[snakeRow, snakeCol] = "S";
                    if (foodEaten == 10)
                    {
                        Console.WriteLine("You won! You fed the snake.");
                        break;
                    }
                }
                else if (matrix[snakeRow, snakeCol] == "B")
                {
                    matrix[snakeRow, snakeCol] = ".";

                    int[] position = FindExit(matrix);

                    matrix[position[0], position[1]] = "S";

                    snakeRow = position[0];
                    snakeCol = position[1];
                }
                else if (matrix[snakeRow, snakeCol] == "-")
                {
                    matrix[snakeRow, snakeCol] = "S";
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            Print(matrix);
        }

        static bool CheckBounderies(string[,] matrix, int snakeRow, int snakeCol)
        {
            return snakeRow < 0 || snakeRow >= matrix.GetLength(0) || snakeCol < 0 || snakeCol >= matrix.GetLength(1);
        }

        static int[] FindExit(string[,] matrix)
        {
            int[] position = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "B")
                    {
                        position = new int[] { i, j };
                    }
                }
            }

            return position;
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
    }
}

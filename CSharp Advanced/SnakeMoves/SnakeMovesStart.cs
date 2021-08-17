using System;
using System.Linq;

namespace SnakeMoves
{
    class SnakeMovesStart
    {
        static void Main()
        {
            int[] dimesions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            string[,] matrix = new string[dimesions[0], dimesions[1]];

            int snakeLength = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snake[snakeLength].ToString();
                        snakeLength++;
                        if (snakeLength == snake.Length)
                        {
                            snakeLength = 0;
                        }
                    }
                }
                else
                {
                    for (int k = matrix.GetLength(1) - 1; k >= 0; k--)
                    {
                        matrix[i, k] = snake[snakeLength].ToString();
                        snakeLength++;
                        if (snakeLength == snake.Length)
                        {
                            snakeLength = 0;
                        }
                    }
                }
            }

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

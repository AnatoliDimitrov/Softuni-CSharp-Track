using System;
using System.Text;

namespace BookWorm
{
    class BookWormStart
    {
        static void Main()
        {
            string word = Console.ReadLine();

            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j].ToString();

                    if (matrix[i, j] == "P")
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up")
                {
                    playerRow--;

                    if (IsOut(matrix, playerRow, playerCol))
                    {
                        word = RemoveFromWord(word);
                        playerRow++;
                    }
                    else
                    {
                        if (matrix[playerRow, playerCol] != "-")
                        {
                            word += matrix[playerRow, playerCol];
                        }
                        matrix[playerRow, playerCol] = "P";
                        matrix[playerRow + 1, playerCol] = "-";
                    }
                }
                else if (command == "down")
                {
                    playerRow++;

                    if (IsOut(matrix, playerRow, playerCol))
                    {
                        word = RemoveFromWord(word);
                        playerRow--;
                    }
                    else
                    {
                        if (matrix[playerRow, playerCol] != "-")
                        {
                            word += matrix[playerRow, playerCol];
                        }
                        matrix[playerRow, playerCol] = "P";
                        matrix[playerRow - 1, playerCol] = "-";
                    }
                }
                else if (command == "left")
                {
                    playerCol--;

                    if (IsOut(matrix, playerRow, playerCol))
                    {
                        word = RemoveFromWord(word);
                        playerCol++;
                    }
                    else
                    {
                        if (matrix[playerRow, playerCol] != "-")
                        {
                            word += matrix[playerRow, playerCol];
                        }
                        matrix[playerRow, playerCol] = "P";
                        matrix[playerRow, playerCol + 1] = "-";
                    }
                }
                else if (command == "right")
                {
                    playerCol++;

                    if (IsOut(matrix, playerRow, playerCol))
                    {
                        word = RemoveFromWord(word);
                        playerCol--;
                    }
                    else
                    {
                        if (matrix[playerRow, playerCol] != "-")
                        {
                            word += matrix[playerRow, playerCol];
                        }
                        matrix[playerRow, playerCol] = "P";
                        matrix[playerRow, playerCol - 1] = "-";

                    }
                }
            }
            Console.WriteLine(word);
            Print(matrix);
        }

        static string RemoveFromWord(string word)
        {
            if (word == "" || word.Length == 1)
            {
                word = "";
            }
            else if (true)
            {
                word = word.Substring(0, word.Length - 1);
            }
            return word;
        }

        static bool IsOut(string[,] matrix, int row, int col)
        {
            int len = matrix.GetLength(0);

            return row < 0 || row == len || col < 0 || col == len;
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

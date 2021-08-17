using System;

namespace Re_Volt
{
    class ReVoltStart
    {
        static void Main()
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            string[,] matrix = new string[sizeOfMatrix, sizeOfMatrix];

            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (line[j].ToString() == "f")
                    {
                        playerRow = i;
                        playerCol = j;
                    }

                    matrix[i, j] = line[j].ToString();
                }
            }

            int[] coordinates = new int[] { playerRow, playerCol };

            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();

                matrix[coordinates[0], coordinates[1]] = "-";

                Move(matrix, command, coordinates);

                if (matrix[coordinates[0], coordinates[1]] == "F")
                {
                    matrix[coordinates[0], coordinates[1]] = "f";
                    Console.WriteLine("Player won!");
                    Print(matrix);
                    return;
                }
                else if (matrix[coordinates[0], coordinates[1]] == "B")
                {
                    Move(matrix, command, coordinates);

                    if (matrix[coordinates[0], coordinates[1]] == "F")
                    {
                        matrix[coordinates[0], coordinates[1]] = "f";
                        Console.WriteLine("Player won!");
                        Print(matrix);
                        return;
                    }

                    matrix[coordinates[0], coordinates[1]] = "f";
                }
                else if (matrix[coordinates[0], coordinates[1]] == "T")
                {
                    command = SwapCommand(command);

                    Move(matrix, command, coordinates);

                    matrix[coordinates[0], coordinates[1]] = "f";
                }
                else if (matrix[coordinates[0], coordinates[1]] == "-")
                {
                    matrix[coordinates[0], coordinates[1]] = "f";
                }
            }

            Console.WriteLine("Player lost!");
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

        static void Move(string[,] matrix, string command, int[] coordinates)
        {
            int playerRow = coordinates[0];
            int playerCol = coordinates[1];

            if (command == "left")
            {
                playerCol--;
                if (playerCol < 0)
                {
                    playerCol = matrix.GetLength(0) - 1;
                }
            }
            else if (command == "right")
            {
                playerCol++;
                if (playerCol == matrix.GetLength(0))
                {
                    playerCol = 0;
                }
            }
            else if (command == "down")
            {
                playerRow++;
                if (playerRow == matrix.GetLength(1))
                {
                    playerRow = 0;
                }
            }
            else if (command == "up")
            {
                playerRow--;
                if (playerRow < 0)
                {
                    playerRow = matrix.GetLength(1) - 1;
                }
            }

            coordinates[0] = playerRow;
            coordinates[1] = playerCol;
        }

        static string SwapCommand(string command)
        {
            if (command == "up")
            {
                command = "down";
            }
            else if (command == "down")
            {
                command = "up";
            }
            else if (command == "left")
            {
                command = "right";
            }
            else if (command == "right")
            {
                command = "left";
            }
            return command;
        }
    }
}

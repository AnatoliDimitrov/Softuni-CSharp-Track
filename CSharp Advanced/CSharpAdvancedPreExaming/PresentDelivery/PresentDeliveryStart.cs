using System;

namespace PresentDelivery
{
    class PresentDeliveryStart
    {
        static void Main()
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            int santaRow = -1;
            int santaCol = -1;

            int happyKids = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (line[j].ToString() == "S")
                    {
                        santaRow = i;
                        santaCol = j;
                    }
                    else if (line[j].ToString() == "V")
                    {
                        happyKids++;
                    } 

                    matrix[i, j] = line[j];
                }
            }

            string command = "";

            while ((command = Console.ReadLine()) != "Christmas morning" && presentsCount > 0)
            {
                matrix[santaRow, santaCol] = "";

                if (command == "up")
                {
                    santaRow--;
                }
                else if (command == "down")
                {
                    santaRow++;
                }
                else if (command == "left")
                {
                    santaCol--;
                }
                else if (command == "right")
                {
                    santaCol++;
                }

                if (CheckBounderies(matrix, santaRow, santaCol))
                {
                    Console.WriteLine("Santa ran out of presents.");
                    break;
                }

                if (matrix[santaRow, santaCol] == "-")
                {
                    matrix[santaRow, santaCol] = "S";
                }
                else if (matrix[santaRow, santaCol] == "V")
                {
                    matrix[santaRow, santaCol] = "S";
                    presentsCount--;

                    if (presentsCount == 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                }
                else if (matrix[santaRow, santaCol] == "X")
                {
                    continue;
                }
                else if (matrix[santaRow, santaCol] == "C")
                {
                    matrix[santaRow, santaCol] = "S";


                    if (matrix[santaRow, santaCol + 1] != "-")// right
                    {
                        presentsCount--;
                        matrix[santaRow, santaCol + 1] = "-";
                        if (presentsCount == 0)
                        {
                            continue;
                        }
                    }
                    if (matrix[santaRow, santaCol - 1] != "-")// left
                    {
                        presentsCount--;
                        matrix[santaRow, santaCol - 1] = "-";
                        if (presentsCount == 0)
                        {
                            continue;
                        }
                    }
                    if (matrix[santaRow - 1, santaCol] != "-")// up
                    {
                        presentsCount--;
                        matrix[santaRow - 1, santaCol] = "-";
                        if (presentsCount == 0)
                        {
                            continue;
                        }
                    }
                    if (matrix[santaRow + 1, santaCol] == "V")// down
                    {
                        presentsCount--;
                        matrix[santaRow + 1, santaCol] = "-";
                        if (presentsCount == 0)
                        {
                            continue;
                        }
                    }
                }
            }

            int goodKidsLeft = 0;

            foreach (var item in matrix)
            {
                if (item == "V")
                {
                    goodKidsLeft++;
                }
            }

            Print(matrix);

            if (goodKidsLeft == 0)
            {
                Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {goodKidsLeft} nice kid/s.");
            }
        }

        static bool CheckBounderies(string[,] matrix, int santaRow, int santaCol)
        {
            return santaRow < 0 || santaRow >= matrix.GetLength(0) || santaCol < 0 || santaCol >= matrix.GetLength(1);
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

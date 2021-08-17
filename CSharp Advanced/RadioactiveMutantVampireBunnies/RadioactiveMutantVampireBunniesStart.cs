using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunniesStart
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            string[,] lair = new string[sizes[0], sizes[1]];

            int playerRow = 0;
            int playerCol = 0;

            for (int i = 0; i < lair.GetLength(0); i++)
            {
                char[] temp = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < temp.Length; j++)
                {
                    lair[i, j] = temp[j].ToString();
                    if (temp[j].ToString() == "P")
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            char[] moves = Console.ReadLine()
                .ToCharArray();

            bool isWinner = false;
            bool isDead = false;

            for (int i = 0; i < moves.Length; i++)
            {
                string move = moves[i].ToString();

                if (move == "L")
                {
                    if (IsOut(lair, playerRow, playerCol - 1))
                    {
                        lair[playerRow, playerCol] = ".";
                        isWinner = true; 
                    }
                    else
                    {
                        if (lair[playerRow, playerCol - 1] == ".")
                        {
                            lair[playerRow, playerCol] = ".";
                            lair[playerRow, playerCol - 1] = "P";
                            playerCol -= 1;
                        }
                        else
                        {
                            playerCol -= 1;
                            isDead = true;
                        }
                    }
                }
                else if (move == "R")
                {
                    if (IsOut(lair, playerRow, playerCol + 1))
                    {
                        lair[playerRow, playerCol] = ".";
                        isWinner = true;
                    }
                    else
                    {
                        if (lair[playerRow, playerCol + 1] == ".")
                        {
                            lair[playerRow, playerCol] = ".";
                            lair[playerRow, playerCol + 1] = "P";
                            playerCol += 1;
                        }
                        else
                        {
                            playerCol += 1;
                            isDead = true;
                        }
                    }
                }
                else if (move == "U")
                {
                    if (IsOut(lair, playerRow - 1, playerCol))
                    {
                        lair[playerRow, playerCol] = ".";
                        isWinner = true;
                    }
                    else
                    {
                        if (lair[playerRow - 1, playerCol] == ".")
                        {
                            lair[playerRow, playerCol] = ".";
                            lair[playerRow - 1, playerCol] = "P";
                            playerRow -= 1;
                        }
                        else
                        {
                            playerRow -= 1;
                            isDead = true;
                        }
                    }
                }
                else if (move == "D")
                {
                    if (IsOut(lair, playerRow + 1, playerCol))
                    {
                        lair[playerRow, playerCol] = ".";
                        isWinner = true;
                    }
                    else
                    {
                        if (lair[playerRow + 1, playerCol] == ".")
                        {
                            lair[playerRow, playerCol] = ".";
                            lair[playerRow + 1, playerCol] = "P";
                            playerRow += 1;
                        }
                        else
                        {
                            playerRow += 1;
                            isDead = true;
                        }
                    }
                }

                bool dead = false;

                List<int[]> bunniesPositions = new List<int[]>();

                for (int j = 0; j < lair.GetLength(0); j++)
                {
                    for (int k = 0; k < lair.GetLength(1); k++)
                    {
                        if (lair[j, k] == "B")
                        {
                            bunniesPositions.Add(new int[] { j, k});
                        }
                    }
                }

                for (int j = 0; j < bunniesPositions.Count; j++)
                {
                    
                    if (SpreadBunnies(lair, bunniesPositions[j][0], bunniesPositions[j][1]))
                    {
                        dead = true;
                    }
                }

                if (isWinner)
                {
                    Print(lair);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }
                if (isDead || dead)
                {
                    Print(lair);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }
        }

        static bool IsOut(string[,] lair, int row, int col)
        {
            return (row < 0 || row >= lair.GetLength(0)) || (col < 0 || col >= lair.GetLength(1));
        }

        static bool SpreadBunnies(string[,]lair, int row, int col)
        {
            bool dead = false;

            int[][] moves = new int[4][];

            moves[0] = new int[] { row, col - 1 };
            moves[1] = new int[] { row, col + 1 };
            moves[2] = new int[] { row - 1, col};
            moves[3] = new int[] { row + 1, col};

            for (int i = 0; i < moves.Length; i++)
            {
                int currentRow = moves[i][0];
                int currentCol = moves[i][1];

                if (!IsOut(lair, currentRow, currentCol))
                {
                    if (lair[currentRow, currentCol] == "P")
                    {
                        dead = true;

                    }

                    lair[currentRow, currentCol] = "B";
                }
            }

            return dead;
        }

        static void Print(string[,] lair)
        {
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write(lair[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

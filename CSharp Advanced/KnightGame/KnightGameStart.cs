using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightGame
{
    class KnightGameStart
    {
        static void Main()
        {
            int dimension = int.Parse(Console.ReadLine());

            string[,] board = new string[dimension, dimension];

            SortedDictionary<int, List<int>> killers = new SortedDictionary<int, List<int>>();

            int counter = 0;

            for (int i = 0; i < dimension; i++)
            {
                char[] chars = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < dimension; j++)
                {
                    board[i, j] = chars[j].ToString();
                }
            }
            while (true)
            {

                List<int> movesCounters = new List<int>();

                List<int[]> movesPositions = new List<int[]>();

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == "K")
                        {
                            movesCounters.Add(MoveKnight(board, i, j));
                            movesPositions.Add(new int[] { i, j });
                        }
                    }
                }

                if (movesCounters.Max() > 0)
                {
                    int index = movesCounters.IndexOf(movesCounters.Max());
                    int rowToRemove = movesPositions[index][0];
                    int colToRemove = movesPositions[index][1];

                    board[rowToRemove, colToRemove] = "0";
                    counter++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(counter);
        }
        static int MoveKnight(string[,]matrix, int row, int col)
        {
            int counter = 0;

            int[][] moves = new int[8][];

                moves[0] = new int[] { row - 2, col - 1};
                moves[1] = new int[] { row - 2, col + 1};
                moves[2] = new int[] { row - 1, col - 2};
                moves[3] = new int[] { row + 1, col - 2};
                moves[4] = new int[] { row + 2, col - 1};
                moves[5] = new int[] { row - 1, col + 2};
                moves[6] = new int[] { row + 1, col + 2};
                moves[7] = new int[] { row + 2, col + 1};

            for (int i = 0; i < moves.Length; i++)
            {
                int movedRow = moves[i][0];
                int movedCol = moves[i][1];

                if ((movedRow >= 0 && movedRow < matrix.GetLength(0)) && (movedCol >= 0 && movedCol < matrix.GetLength(1)))
                {
                    if (matrix[movedRow, movedCol] == "K")
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}

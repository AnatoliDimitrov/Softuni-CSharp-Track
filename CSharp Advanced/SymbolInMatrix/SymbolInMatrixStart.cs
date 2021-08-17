using System;

namespace SymbolInMatrix
{
    class SymbolInMatrixStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] chars = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = chars[j].ToString();
                }
            }

            string toFind = Console.ReadLine();

            int row = -1;
            int col = -1;

            bool finded = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == toFind)
                    {
                        row = i;
                        col = j;
                        finded = true;
                        break;
                    }
                }
                if (finded)
                {
                    break;
                }
            }

            if (row >= 0)
            {
                Console.WriteLine($"({row}, {col})");
            }
            else
            {
                Console.WriteLine($"{toFind} does not occur in the matrix ");
            }
        }
    }
}

using System;

namespace PascalTriangle
{
    class PascalTriangleStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                Console.WriteLine();
                return;
            }
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }

            long[][] triangle = new long[n][];

            triangle[0] = new long[] { 1 };
            triangle[1] = new long[] { 1, 1 };

            for (int i = 2; i < n; i++)
            {
                triangle[i] = new long[i + 1];
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    if (j == 0 || j == triangle[i].Length - 1)
                    {
                        triangle[i][j] = 1;
                    }
                    else
                    {
                        triangle[i][j] = triangle[i - 1][j] + triangle[i - 1][j - 1];
                    }
                }
            }

            foreach (var item in triangle)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}

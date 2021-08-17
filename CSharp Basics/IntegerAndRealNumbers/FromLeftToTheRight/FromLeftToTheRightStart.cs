namespace FromLeftToTheRight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class FromLeftToTheRightStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<BigInteger>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list = input.Split(' ').Select(BigInteger.Parse).ToList();
                var chars = BigInteger.Abs(list.Max()).ToString().ToCharArray();
                BigInteger sum = 0;

                foreach (var item in chars)
                {
                    sum += BigInteger.Parse(item.ToString());
                }
                Console.WriteLine(sum);
            }
        }
    }
}

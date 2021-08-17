namespace ExactSumRealNumbers
{
    using System;
    using System.Numerics;

    class ExactSumRealNumbersStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Decimal sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }
    }
}

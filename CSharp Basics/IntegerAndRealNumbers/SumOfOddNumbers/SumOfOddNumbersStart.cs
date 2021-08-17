namespace SumOfOddNumbers
{
    using System;
    class SumOfOddNumbersStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 0;

            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 != 0)
                {
                    counter++;
                    sum += i;
                    Console.WriteLine(i);
                }
                if (counter == n)
                {
                    break;
                }
            }
            Console.WriteLine("Sum: {0}",sum);
        }
    }
}

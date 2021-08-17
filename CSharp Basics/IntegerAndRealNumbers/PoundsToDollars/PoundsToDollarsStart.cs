namespace PoundsToDollars
{
    using System;
    class PoundsToDollarsStart
    {
        static void Main()
        {
            double pounds = double.Parse(Console.ReadLine());
            double dollars = pounds * 1.31;

            Console.WriteLine("{0:0.000}", dollars);
        }
    }
}

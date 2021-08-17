namespace FloatingEquality
{
    using System;
    class FloatingEqualityStart
    {
        static void Main()
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());

            double difference = 0;

            if (first > second)
            {
                difference = first - second;
            }
            else
            {
                difference = second - first;
            }

            if (difference >= 0.000001 )
            {
                Console.WriteLine(false);
            }
            else
            {
                Console.WriteLine(true);
            }
        }
    }
}

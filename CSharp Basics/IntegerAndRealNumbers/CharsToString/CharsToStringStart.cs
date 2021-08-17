namespace CharsToString
{
    using System;
    class CharsToStringStart
    {
        static void Main()
        {
            char first = Console.ReadLine()[0];
            char second = Console.ReadLine()[0];
            char third = Console.ReadLine()[0];

            Console.WriteLine(first.ToString() + second.ToString() + third.ToString());
        }
    }
}

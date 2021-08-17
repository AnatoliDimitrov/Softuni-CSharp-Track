using System;

namespace EvenNumber
{
    class EvenNumberStart
    {
        static void Main()
        {
            int n;

            while ((n = int.Parse(Console.ReadLine())) % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
            }
            Console.WriteLine("The number is: {0}", Math.Abs(n));
        }
    }
}

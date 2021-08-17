using System;
using System.Collections.Generic;

namespace DecimalToBinaryConverter
{
    class DecimalToBinaryConverterStart
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Stack<int> binary = new Stack<int>();

            while (number > 0)
            {
                binary.Push(number % 2);
                number = number / 2;
            }

            foreach (var item in binary)
            {
                Console.Write(item);
            }
        }
    }
}

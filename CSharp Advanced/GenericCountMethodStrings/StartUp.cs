using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<double> elements = new List<double>();

            for (int i = 0; i < n; i++)
            {
                elements.Add(double.Parse(Console.ReadLine()));
            }

            double element = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(elements);

            Console.WriteLine(box.FindLargerElememts(element));
        }
    }
}

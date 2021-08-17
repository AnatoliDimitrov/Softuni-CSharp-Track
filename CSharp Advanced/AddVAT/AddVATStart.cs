using System;
using System.Linq;

namespace AddVAT
{
    class AddVATStart
    {
        static void Main()
        {
            Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .Select(n => n * 1.2)
                 .ToList()
                 .ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}

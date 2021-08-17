namespace CustomMinFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class CustomMinFunctionStart
    {
        static void Main()
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            Func<List<double>, double> min = n => n.Min();

            Console.WriteLine(min(nums));
        }
    }
}

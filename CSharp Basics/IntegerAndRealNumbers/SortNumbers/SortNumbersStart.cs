namespace SortNumbers
{
    using System;
    using System.Collections.Generic;

    class SortNumbersStart
    {
        static void Main()
        {
            var numbers = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            numbers.Sort();

            for (int j = numbers.Count - 1; j >= 0; j--)
            {
                Console.WriteLine(numbers[j]);
            }
        }
    }
}

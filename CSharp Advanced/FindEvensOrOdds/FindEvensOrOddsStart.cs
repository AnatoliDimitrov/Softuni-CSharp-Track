namespace FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class FindEvensOrOddsStartcs
    {
        static void Main()
        {
            int[] bounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            List<int> list = new List<int>();

            Predicate<int> predicate = EvenOrOdd(command);

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))
                {
                    list.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", list));

        }

        static Predicate<int> EvenOrOdd(string command)
        {
            return command switch
            {
                "odd" => new Predicate<int>(n => n % 2 != 0),
                "even" => new Predicate<int>(n => n % 2 == 0)
            };
        }
    }
}

namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfPredicatesStart
    {
        static void Main()
        {
            int range = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> predicate = new Func<int, int[], bool>(IsDividing);

            var list = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                if (predicate(i, dividers))
                {
                    list.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        static bool IsDividing(int n, int[] dividers)
        {
            bool dividedByAll = true;
            for (int i = 0; i < dividers.Length; i++)
            {
                if (n % dividers[i] != 0)
                {
                    dividedByAll = false;
                    break;
                }
            }

            return dividedByAll;
        }
    }
}

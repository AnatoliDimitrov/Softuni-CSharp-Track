namespace CustomComparator
{
    using System;
    using System.Linq;

    class CustomComparatorStart
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Comparison<int> comparison = new Comparison<int>(CompareNumbers);

            Comparison<int> secondComparison = new Comparison<int>(OddsAfterEvens);

            Array.Sort(numbers, comparison);

            Array.Sort(numbers, secondComparison);

            Console.WriteLine(string.Join(" ", numbers));
        }

        static int CompareNumbers(int a, int b)
        {
            if (a > b)
            {
                return 1;
            }
            else if (a < b)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        static int OddsAfterEvens(int a, int b)
        {
            if (a % 2 == 0 && b % 2 != 0)
            {
                return -1;
            }
            else if (a % 2 != 0 && b % 2 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

namespace TriFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TriFunctionStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<int, bool> function = new Func<int, bool>(len => len >= n);

            for (int i = 0; i < names.Count; i++)
            {
                bool winner = Traverse(function, names[i], n);
                if (winner)
                {
                    Console.WriteLine(names[i]);
                    break;
                }
            }


        }

        static bool Traverse(Func<int, bool> function, string name, int n)
        {

            

            int sum = 0;

            for (int i = 0; i < name.Length; i++)
            {
                sum += name[i];
            }
            bool isBigger = function(sum);

            return isBigger;
        }
    }
}

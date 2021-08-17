using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBox
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            Box<int> box = new Box<int>(list);

            int[] swapIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            box.Swap(swapIndexes[0], swapIndexes[1]);

            Console.WriteLine(box);
        }
    }
}

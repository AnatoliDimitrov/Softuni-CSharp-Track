namespace MaximumAndMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaximumAndMinimumElementStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int command = query[0];

                if (command == 1)
                {
                    stack.Push(query[1]);
                }
                else if (command == 2 && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (command == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}

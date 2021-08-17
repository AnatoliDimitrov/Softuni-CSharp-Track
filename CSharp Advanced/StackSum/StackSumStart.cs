namespace StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StackSumStart
    {
        static void Main()
        {
            var list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> stack = new Stack<int>(list);

            string input = "";

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] instructions = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = instructions[0];

                if (command == "add")
                {
                    for (int i = 1; i < 2; i++)
                    {
                        stack.Push(int.Parse(instructions[i]));
                    }
                }
                else
                {
                    int count = int.Parse(instructions[1]);

                    if (count > stack.Count)
                    {
                        continue;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        stack.Pop();
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}

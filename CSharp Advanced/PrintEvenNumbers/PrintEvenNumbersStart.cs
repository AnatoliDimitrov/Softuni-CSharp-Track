namespace PrintEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PrintEvenNumbersStart
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> q = new Queue<int>(nums);
            Queue<int> result = new Queue<int>();

            while (q.Count != 0)
            {
                if (q.Peek() % 2 == 0)
                {
                    result.Enqueue(q.Dequeue());
                }
                else
                {
                    q.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}

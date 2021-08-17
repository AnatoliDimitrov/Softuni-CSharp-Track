using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceWithQueue
{
    class SequenceWithQueueStart
    {
        static void Main()
        {
            long s = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();

            List<long> list = new List<long>();

            queue.Enqueue(s);
            list.Add(s);

            for (int j = 0; j < 17; j++)
            {
                queue.Enqueue(list[j] + 1);
                queue.Enqueue(2 * list[j] + 1);
                queue.Enqueue(list[j] + 2);

                list.Add(list[j] + 1);
                list.Add(2 * list[j] + 1);
                list.Add(list[j] + 2);

            }

            Console.WriteLine(string.Join(" ", queue.Take(50)));
        }
    }
}

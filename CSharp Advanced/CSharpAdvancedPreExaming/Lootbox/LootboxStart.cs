using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class LootboxStart
    {
        static void Main()
        {
            int[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queueBox = new Queue<int>(firstInput);

            var stackBox = new Stack<int>(secondInput);

            var collection = new List<long>();

            while (true)
            {
                if ((queueBox.Peek() + stackBox.Peek()) % 2 == 0)
                {
                    collection.Add(queueBox.Dequeue() + stackBox.Pop());
                    if (queueBox.Count == 0 || stackBox.Count == 0)
                    {
                        break;
                    }
                }
                else
                {
                    queueBox.Enqueue(stackBox.Pop());
                    if (stackBox.Count == 0)
                    {
                        break;
                    }
                }
            }

            if (queueBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (stackBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            long loot = collection.Sum();

            if (loot >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {loot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {loot}");
            }
        }
    }
}

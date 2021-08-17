using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    class SantasPresentFactoryStart
    {
        static void Main()
        {
            int[] materialsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] magicLevelsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stackMaterials = new Stack<int>(materialsInput);

            var queueMagic = new Queue<int>(magicLevelsInput);

            var pairs = new Dictionary<string, int>();

            pairs.Add("Doll", 0);
            pairs.Add("Wooden train", 0);
            pairs.Add("Teddy bear", 0);
            pairs.Add("Bicycle", 0);

            bool havePair = false;

            while (stackMaterials.Count > 0 && queueMagic.Count > 0)
            {
                int multyplicated = stackMaterials.Peek() * queueMagic.Peek();
                if (multyplicated == 0)
                {
                    if (stackMaterials.Peek() == 0)
                    {
                        stackMaterials.Pop();
                    }
                    if (queueMagic.Peek() == 0)
                    {
                        queueMagic.Dequeue();
                    }

                    continue;
                }
                else if (multyplicated < 0)
                {
                    stackMaterials.Push(stackMaterials.Pop() + queueMagic.Dequeue());
                }
                else
                {
                    if (multyplicated == 150)
                    {
                        pairs["Doll"]++;
                        stackMaterials.Pop();
                        queueMagic.Dequeue();
                    }
                    else if (multyplicated == 250)
                    {
                        pairs["Wooden train"]++;
                        stackMaterials.Pop();
                        queueMagic.Dequeue();
                    }
                    else if (multyplicated == 300)
                    {
                        pairs["Teddy bear"]++;
                        stackMaterials.Pop();
                        queueMagic.Dequeue();
                    }
                    else if (multyplicated == 400)
                    {
                        pairs["Bicycle"]++;
                        stackMaterials.Pop();
                        queueMagic.Dequeue();
                    }
                    else
                    {
                        queueMagic.Dequeue();
                        stackMaterials.Push(stackMaterials.Pop() + 15);
                    }
                }
            }

            havePair = HavePair(pairs);

            if (havePair)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (stackMaterials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", stackMaterials)}");
            }

            if (queueMagic.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", queueMagic)}");
            }

            var sorted = pairs
                .Where(p => p.Value > 0)
                .OrderBy(p => p.Key);

            foreach (var (key, value) in sorted)
            {
                Console.WriteLine($"{key}: {value}");
            }
        }

        static bool HavePair(Dictionary<string, int> presents)
        {
            if (presents["Doll"] > 0 && presents["Wooden train"] > 0)
            {
                return true;
            }
            else if (presents["Teddy bear"] > 0 && presents["Bicycle"] > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

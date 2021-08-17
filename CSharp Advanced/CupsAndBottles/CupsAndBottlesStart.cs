namespace CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CupsAndBottlesStart
    {
        static void Main()
        {
            var inputCups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var inputBottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(inputCups);

            Stack<int> bottles = new Stack<int>(inputBottles);

            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Peek();

                while (currentCup > 0)
                {
                    currentCup -= bottles.Pop();

                    if (currentCup < 0)
                    {
                        wastedWater += Math.Abs(currentCup);

                        cups.Dequeue();
                    }
                    else if (currentCup == 0)
                    {
                        cups.Dequeue();
                        break;
                    }
                }
            }
            if (bottles.Count != 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Count != 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}

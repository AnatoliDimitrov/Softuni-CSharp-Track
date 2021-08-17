using System;
using System.Collections.Generic;

namespace HotPotato
{
    class HotPotatoStart
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ");
            Queue<string> kids = new Queue<string>(input);

            int tosses = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                for (int i = 1; i < tosses; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}

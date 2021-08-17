namespace FashionBoutique
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class FashionBoutiqueStart
    {
        static void Main()
        {
            int[] box = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> clothes = new Stack<int>(box);

            int rackCapacity = int.Parse(Console.ReadLine());

            int racks = 1;

            int currentRack = 0;

            while (clothes.Count > 0)
            {
                if (clothes.Peek() + currentRack <= rackCapacity )
                {
                    currentRack += clothes.Pop();
                }
                else
                {
                    currentRack = 0;
                    racks++;
                }
            }

            Console.WriteLine(racks);
        }
    }
}

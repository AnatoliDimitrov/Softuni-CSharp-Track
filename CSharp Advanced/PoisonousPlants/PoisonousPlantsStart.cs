using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    class PoisonousPlantsStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> plants = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> indexes = new List<int>();

            int counter = 0;

            while (true)
            {
                for (int i = 0; i < plants.Count - 1; i++)
                {
                    if (plants[i] < plants[i + 1])
                    {
                        indexes.Add(i + 1);
                    }
                }

                if (indexes.Count > 0)
                {
                    for (int i = 0; i < indexes.Count; i++)
                    {
                        plants.RemoveAt(indexes[i] - i);
                    }
                    indexes = new List<int>();
                    counter++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}

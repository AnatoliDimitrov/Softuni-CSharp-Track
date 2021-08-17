using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTourStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }

            int index = 0;

            while (true)
            {
                int fuel = 0;

                bool reached = true;


                foreach (var item in pumps)
                {
                    fuel += item[0];
                    fuel -= item[1];

                    if (fuel < 0)
                    {
                        reached = false;
                        index++;
                        break;
                    }
                }

                if (reached)
                {
                    Console.WriteLine(index);
                    break;
                }

                pumps.Enqueue(pumps.Dequeue());
            }
        }
    }
}

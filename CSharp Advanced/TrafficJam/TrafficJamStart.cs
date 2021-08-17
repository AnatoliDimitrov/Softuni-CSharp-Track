using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class TrafficJamStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            Queue<string> traffic = new Queue<string>();

            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    traffic.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (traffic.Count != 0)
                        {
                            Console.WriteLine($"{traffic.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}

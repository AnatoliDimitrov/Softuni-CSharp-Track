namespace FastFood
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class FastFoodStart
    {
        static void Main()
        {
            double foodQuantity = double.Parse(Console.ReadLine());

            double[] orders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Queue<double> clients = new Queue<double>(orders);

            if (clients.Count > 0)
            {
                Console.WriteLine(orders.Max());
            }

            while (clients.Count > 0)
            {
                if (clients.Peek() <= foodQuantity)
                {
                    foodQuantity -= clients.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (clients.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", clients)}");
            }
        }
    }
}

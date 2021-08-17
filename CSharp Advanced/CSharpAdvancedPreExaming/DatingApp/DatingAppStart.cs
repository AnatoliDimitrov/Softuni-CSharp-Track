using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class DatingAppStart
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var females = new Queue<int>(secondInput);

            var males = new Stack<int>(firstInput);

            int matches = 0;

            while (females.Any() && males.Any())
            {
                int male = males.Peek();
                int female = females.Peek();

                if (male <= 0 || female <= 0)
                {
                    if (male <= 0)
                    {
                        males.Pop();
                    }
                    if (female <= 0)
                    {
                        females.Dequeue();
                    }
                }

                else if (male % 25 == 0 || female % 25 == 0)
                {

                    if (male % 25 == 0)
                    {
                        males.Pop();
                        males.Pop();
                    }

                    if (female % 25 == 0)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }
                }

                else if (male == female)
                {
                    females.Dequeue();
                    males.Pop();

                    matches++;
                }
                else
                {
                    females.Dequeue();
                    int temp = males.Pop();

                    males.Push(temp - 2);
                }
            }

            Console.WriteLine($"Matches: {matches}");


            if (males.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }

            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
        }
    }
}

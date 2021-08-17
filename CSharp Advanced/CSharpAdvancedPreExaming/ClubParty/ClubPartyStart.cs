using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class ClubPartyStart
    {
        static void Main()
        {
            int maximumCapacity = int.Parse(Console.ReadLine());

            string[] info = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> hallsAndPeople = new Stack<string>(info);

            var club = new Dictionary<char, List<int>>();

            List<int> companies = new List<int>();
            List<char> halls = new List<char>();

            while (hallsAndPeople.Count > 0)
            {
                string current = hallsAndPeople.Pop();

                int currentNumber = 0;

                if (int.TryParse(current, out currentNumber))
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }
                }
                else
                {
                    halls.Add(char.Parse(current));
                    club.Add(char.Parse(current), new List<int>());
                    continue;
                }

                if (club.Count != 0)
                {
                    if (club[halls[0]].Sum() + currentNumber > maximumCapacity)
                    {
                        Console.WriteLine($"{halls[0]} -> {string.Join(", ", club[halls[0]])}");
                        halls.RemoveAt(0);
                        if (halls.Count == 0)
                        {
                            continue;
                        }
                        club[halls[0]].Add(currentNumber);
                        continue;
                    }
                    else
                    {
                        club[halls[0]].Add(currentNumber);
                    }
                }
            }
        }
    }
}

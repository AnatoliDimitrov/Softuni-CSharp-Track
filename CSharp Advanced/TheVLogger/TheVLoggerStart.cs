using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class TheVLoggerStart
    {
        static void Main()
        {
            Dictionary<string, SortedSet<string>> vloggersWithFollers = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, SortedSet<string>> vloggersWhoFollowed = new Dictionary<string, SortedSet<string>>();

            string input = "";

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] follow = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = follow[1];

                if (command == "joined")
                {
                    string name = follow[0];
                    if (!vloggersWithFollers.ContainsKey(name))
                    {
                        vloggersWithFollers[name] = new SortedSet<string>();
                        vloggersWhoFollowed[name] = new SortedSet<string>();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "followed")
                {
                    string follower = follow[0];
                    string followed = follow[2];

                    if (vloggersWithFollers.ContainsKey(follower) && vloggersWithFollers.ContainsKey(followed) && (follower != followed))
                    {
                        vloggersWithFollers[followed].Add(follower);
                        vloggersWhoFollowed[follower].Add(followed);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggersWithFollers.Count} vloggers in its logs.");

            int counter = 1;

            var sorted = vloggersWithFollers
                .OrderByDescending(v => v.Value.Count)
                .ThenBy(v => vloggersWhoFollowed[v.Key].Count);

            foreach (var vlogger in sorted)
            {

                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Count} followers, {vloggersWhoFollowed[vlogger.Key].Count} following");

                if (counter == 1)
                {
                    foreach (var item in vlogger.Value)
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }

                counter++;
            }
        }
    }
}

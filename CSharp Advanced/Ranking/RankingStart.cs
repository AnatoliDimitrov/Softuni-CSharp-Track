using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class RankingStart
    {
        static void Main()
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input = "";

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] inputInfo = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = inputInfo[0];
                string pass = inputInfo[1];

                contests[contest] = pass;
            }

            Dictionary<string, Dictionary<string, int>> contestors = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] submission = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = submission[0];
                string password = submission[1];
                string user = submission[2];
                int points = int.Parse(submission[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!contestors.ContainsKey(user))
                    {
                        contestors[user] = new Dictionary<string, int>() { { contest, points } };
                    }
                    else if (!contestors[user].ContainsKey(contest))
                    {
                        contestors[user][contest] = points;
                    }
                    else if (contestors[user][contest] < points)
                    {
                        contestors[user][contest] = points;
                    }
                }
            }

            var best = contestors
                .OrderByDescending(c => c.Value.Values.Sum());
            foreach (var contestor in best)
            {
                Console.WriteLine($"Best candidate is {contestor.Key} with total {contestor.Value.Values.Sum()} points.");
                break;
            }

            Console.WriteLine("Ranking:");

            var sorted = contestors
                .OrderBy(c => c.Key);

            foreach (var contestor in sorted)
            {
                Console.WriteLine(contestor.Key);

                foreach (var contest in contestor.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}

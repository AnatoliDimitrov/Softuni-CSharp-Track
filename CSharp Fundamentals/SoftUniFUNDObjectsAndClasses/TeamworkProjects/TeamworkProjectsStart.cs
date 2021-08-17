using System.Collections.Generic;

namespace TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TeamworkProjectsStart
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split("-");
                string user = input[0];
                string teamName = input[1];

                var checkUser = teams.Find(us => us.Creator == user);
                var checkName = teams.Find(n => n.Name == teamName);

                if (checkUser != null)
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
                if (checkName != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                if (checkName == null && checkUser == null)
                {
                    teams.Add(new Team(teamName, user));
                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                }
            }

            string command = "";

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] joiner = command.Split("->");
                string userName = joiner[0];
                string teamToJoin = joiner[1];

                var checkTeam = teams.Find(n => n.Name == teamToJoin);
                if (checkTeam == null)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }
                var checkUserName = teams.Find(c => c.Creator == userName);
                if (checkUserName != null)
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamToJoin}!");
                    continue;
                }
                checkUserName = teams.Find(m => m.Members.Contains(userName));
                if (checkUserName != null)
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamToJoin}!");
                    continue;
                }
                checkUserName = teams.Find(t => t.Name == teamToJoin);
                checkUserName.Members.Add(userName);
            }

            List<Team> continues = new List<Team>(); 
            List<Team> disband = new List<Team>();

            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Count == 0)
                {
                    disband.Add(teams[i]);
                }
                else
                {
                    continues.Add(teams[i]);
                }
            }

            disband = disband.OrderBy(t => t.Name).ToList();
            continues = continues.OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name).ToList();

            for (int j = 0; j < continues.Count; j++)
            {
                Console.WriteLine(continues[j].Name);
                Console.WriteLine("- " + continues[j].Creator);
                continues[j].Members = continues[j].Members.OrderBy(m => m).ToList();
                foreach (var member in continues[j].Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in disband)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}

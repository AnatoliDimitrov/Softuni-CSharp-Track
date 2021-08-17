using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Engine
    {

        private List<Team> teams;

        public Engine()
        {
            teams = new List<Team>();
        }

        public void Run()
        {

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputInfo = input
                    .Split(";", StringSplitOptions.None);

                string command = inputInfo[0].ToLower();
                string teamName = inputInfo[1];

                try
                {
                    if (command == "team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (command == "add")
                    {
                        AddPlayerToTeam(inputInfo, teamName);
                    }
                    else if (command == "remove")
                    {
                        RemovePlayerFromTeam(inputInfo, teamName);
                    }
                    else if (command == "rating")
                    {
                        Team team = teams
                            .FirstOrDefault(t => t.Name == teamName);

                        if (team == null)
                        {
                            throw new InvalidOperationException(String.Format(GlobalExceptionMessages.invalidTeam, teamName));
                        }

                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        private void RemovePlayerFromTeam(string[] inputInfo, string teamName)
        {
            Team team = teams
                   .FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArrayTypeMismatchException(String.Format(GlobalExceptionMessages.invalidTeam, teamName));
            }

            team.RemovePlayer(inputInfo[2]);
        }

        private void AddPlayerToTeam(string[] inputInfo, string teamName)
        {
            string playerName = inputInfo[2];
            int endurance = int.Parse(inputInfo[3]);
            int sprint = int.Parse(inputInfo[4]);
            int dribble = int.Parse(inputInfo[5]);
            int passing = int.Parse(inputInfo[6]);
            int shooting = int.Parse(inputInfo[7]);

            Team team = teams
                .FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException(String.Format(GlobalExceptionMessages.invalidTeam, teamName));
            }

            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            team.AddPlayer(player);
        }
    }
}
//throw new ArrayTypeMismatchException();
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Engine
    {
        private List<Person> people;

        public Engine()
        {
            people = new List<Person>();
        }

        public void Run()
        {
            int counter = int.Parse(Console.ReadLine());

            Team team = new Team("SoftUni");

            for (int i = 0; i < counter; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                try
                {
                    var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));

                    team.AddPlayer(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}

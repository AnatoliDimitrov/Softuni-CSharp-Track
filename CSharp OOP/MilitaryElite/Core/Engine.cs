using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private ICollection<Soldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<Soldier>();
        }

        public void Run()
        {
            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = info[0];
                int id = int.Parse(info[1]);

                if (type == "Private")
                {
                    string firstName = info[2];
                    string lastName = info[3];
                    decimal salary = decimal.Parse(info[4]);

                    soldiers.Add(new Private(id, firstName, lastName, salary));
                }
                else if (type == "LieutenantGeneral")
                {
                    string firstName = info[2];
                    string lastName = info[3];
                    decimal salary = decimal.Parse(info[4]);

                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < info.Length; i++)
                    {
                        Private privateToAdd = (Private)soldiers.First(s => s.Id == int.Parse(info[i]));
                        general.AddPrivate(privateToAdd);
                    }

                    soldiers.Add(general);
                }
                else if (type == "Engineer")
                {
                    string firstName = info[2];
                    string lastName = info[3];
                    decimal salary = decimal.Parse(info[4]);
                    string corps = info[5];

                    Engineer engineer;

                    try
                    {

                        engineer = new Engineer(id, firstName, lastName, salary, corps);
                    }
                    catch (ArgumentException)
                    {

                        continue;
                    }

                    for (int i = 6; i < info.Length; i += 2)
                    {
                        string name = info[i];
                        int hours = int.Parse(info[i + 1]);
                        Repair repair = new Repair(name, hours);

                        engineer.AddRepair(repair);
                    }

                    soldiers.Add(engineer);
                }
                else if (type == "Commando")
                {
                    string firstName = info[2];
                    string lastName = info[3];
                    decimal salary = decimal.Parse(info[4]);
                    string corps = info[5];

                    Commando commando;

                    try
                    {
                        commando = new Commando(id, firstName, lastName, salary, corps);
                    }
                    catch (ArgumentException)
                    {

                        continue;
                    }

                    for (int i = 6; i < info.Length; i += 2)
                    {
                        string name = info[i];
                        string progress = info[i + 1];
                        Mission mission;
                        try
                        {

                            mission = new Mission(name, progress);
                        }
                        catch (ArgumentException)
                        {

                            continue;
                        }

                        commando.AddMission(mission);
                    }

                    soldiers.Add(commando);
                }
                else if (type == "Spy")
                {
                    string firstName = info[2];
                    string lastName = info[3];
                    int codeNumber = int.Parse(info[4]);

                    soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}

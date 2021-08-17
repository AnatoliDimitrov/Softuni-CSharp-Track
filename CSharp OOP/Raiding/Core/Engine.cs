using Raiding.Contracts;
using Raiding.Models;
using System;
using System.Collections.Generic;

namespace Raiding.Core
{
    public class Engine
    {

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            List<IHero> heroes = new List<IHero>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Druid")
                {
                    heroes.Add(new Druid(name));
                }
                else if (type == "Paladin")
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type == "Rogue")
                {
                    heroes.Add(new Rogue(name));
                }
                else if (type == "Warrior")
                {
                    heroes.Add(new Warrior(name));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }

            int boss = int.Parse(Console.ReadLine());
            int allPower = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                allPower += hero.Power;
            }

            if (allPower >= boss)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}

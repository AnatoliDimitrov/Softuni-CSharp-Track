using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Numerics;

namespace Problem03
{
    class _03Start
    {
        static void Main()
        {
            Dictionary<string, List<long>> cities = new Dictionary<string, List<long>>();

            string city = "";

            while ((city = Console.ReadLine()) != "Sail")
            {
                string[] data = city.Split("||", StringSplitOptions.None);
                string name = data[0];
                long population = long.Parse(data[1]);
                long gold = long.Parse(data[2]);

                if (!cities.ContainsKey(name))
                {
                    cities[name] = new List<long>() { population, gold };
                }
                else
                {
                    cities[name][0] += population;
                    cities[name][1] += gold;
                }
            }

            string attack = "";

            while ((attack = Console.ReadLine()) != "End")
            {
                string[] instructions = attack.Split("=>", StringSplitOptions.None);
                string command = instructions[0];
                string town = instructions[1];

                if (command == "Plunder")
                {
                    long people = long.Parse(instructions[2]);
                    long gold = long.Parse(instructions[3]);
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    cities[town][0] -= people;
                    cities[town][1] -= gold;

                    if (cities[town][0] == 0 || cities[town][1] == 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        cities.Remove(town);
                    }
                }
                else if (command == "Prosper")
                {
                    long gold = long.Parse(instructions[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                    }
                }
            }

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                return;
            }

            Console.WriteLine($"Ahoy, Captain! There are {cities.Count()} wealthy settlements to go to:");

            var sorted = cities
                .OrderByDescending(c => c.Value[1])
                .ThenBy(c => c.Key);
           
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key} -> Population: {item.Value[0]} citizens, Gold: {item.Value[1]} kg");
            }
        }
    }
}

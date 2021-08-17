using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class CitiesByContinentAndCountryStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> earth = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!earth.ContainsKey(continent))
                {
                    earth[continent] = new Dictionary<string, List<string>>() { { country, new List<string>() { city } } };
                }
                else
                {
                    if (!earth[continent].ContainsKey(country))
                    {
                        earth[continent].Add(country, new List<string>() { city });
                    }
                    else
                    {
                        earth[continent][country].Add(city);
                    }
                }
            }

            foreach (var item in earth)
            {
                Console.WriteLine($"{item.Key}:");

                foreach (var country in item.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}

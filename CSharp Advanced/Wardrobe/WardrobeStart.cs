using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class WardrobeStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];
                string[] items = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                for (int j = 0; j < items.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(items[j]))
                    {
                        wardrobe[color][items[j]] = 0;
                    }
                    wardrobe[color][items[j]]++;
                }
            }

            string[] searchFor = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorSearch = searchFor[0];
            string itemSearch = searchFor[1];

            foreach (var (key, value) in wardrobe)
            {
                Console.WriteLine($"{key} clothes:");

                foreach (var item in value)
                {
                    if (key == colorSearch && item.Key == itemSearch)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}

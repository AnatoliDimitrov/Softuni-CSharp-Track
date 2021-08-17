using System;
using System.Collections.Generic;

namespace Problem_4._Even_Times
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            string repeatingNumb = "";

            for (int i = 0; i < n; i++)
            {
                string numbs = Console.ReadLine();

                if (dictionary.ContainsKey(numbs))
                {
                    dictionary[numbs] = numbs;
                    repeatingNumb = dictionary.GetValueOrDefault(numbs);
                }

                dictionary.TryAdd(numbs, "");
            }

            Console.WriteLine(repeatingNumb);
        }
    }
}
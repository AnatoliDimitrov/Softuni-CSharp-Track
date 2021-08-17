using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main()
        {
            string input = "";

            List<IBirthable> visitors = new List<IBirthable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = info[0];

                if (type == "Citizen")
                {
                    visitors.Add(new Citizen(info[1], int.Parse(info[2]), info[3], info[4]));
                }
                else if (type == "Pet")
                {
                    visitors.Add(new Pet(info[1], info[2]));
                }
            }

            string year = Console.ReadLine();

            List<string> years = new List<string>();

            foreach (var visitor in visitors)
            {
                if (visitor.Birthdate.EndsWith(year))
                {
                    years.Add(visitor.Birthdate);
                }
            }

            if (years.Count == 0)
            {
                Console.WriteLine("");
            }
            else
            {
                foreach (var currentYear in years)
                {
                    Console.WriteLine(currentYear);
                }
            }
        }
    }
}

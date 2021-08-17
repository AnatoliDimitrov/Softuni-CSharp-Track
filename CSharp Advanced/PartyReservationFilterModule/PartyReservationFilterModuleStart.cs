namespace PartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PartyReservationFilterModuleStart
    {
        static void Main()
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var filters = new Dictionary<string, Func<string, bool>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] instructions = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = instructions[0];
                string filter = instructions[1];
                string criteria = instructions[2];
                string filterName = filter + ":" + criteria;

                if (command.StartsWith("Add"))
                {
                    filters.Add(filterName, AddFilter(filter, criteria));
                }
                else
                {
                    filters.Remove(filterName);
                }

            }

            foreach (var filter in filters)
            {
                names = names
                    .Where(filter.Value)
                    .ToList();
            }

            Console.WriteLine(string.Join(" ", names));
        }

        static Func<string, bool> AddFilter(string filter, string criteria)
        {
            return filter switch
            {
                "Starts with" => new Func<string, bool>(n => !n.StartsWith(criteria)),
                "Ends with" => new Func<string, bool>(n => !n.EndsWith(criteria)),
                "Length" => new Func<string, bool>(n => !(n.Length == int.Parse(criteria))),
                _ => new Func<string, bool>(n => !n.Contains(criteria))
            };
        }
    }
}

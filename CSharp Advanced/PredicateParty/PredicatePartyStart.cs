namespace PredicateParty
{
    using System;
    using System.Linq;

    class PredicatePartyStart
    {
        static void Main()
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = "";

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] instructions = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = instructions[0];
                string criteria = instructions[1];
                string filter = instructions[2];

                Predicate<string> predicate = Filter(criteria, filter);

                if (command == "Remove")
                {
                    names = names
                        .Where(n => !predicate(n))
                        .ToList();
                }
                else
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (predicate(names[i]))
                        {
                            names.Insert(i + 1, names[i]);
                            i++;
                        }
                    }
                }
            }
            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> Filter(string criteria, string filter)
        {
            return criteria switch
            {
                "StartsWith" => new Predicate<string>(n => n.StartsWith(filter)),
                "EndsWith" => new Predicate<string>(n => n.EndsWith(filter)),
                _ => new Predicate<string>(n => n.Length == int.Parse(filter))
            };
        }
    }
}

namespace FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FilterByAgeStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                people.Add(new Person(name, age));
            }

            string filterInput = Console.ReadLine();

            int conditionInput = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = filterInput switch
            {
                "older" => p => p.Age >= conditionInput,
                "younger" => p => p.Age < conditionInput,
            };

            var filtered = people
                .Where(filter)
                .ToList();

            string printCondition = Console.ReadLine();

            Func<Person, string> print = printCondition switch
            {
                "name" => p => $"{p.Name}",
                "name age" => p => $"{p.Name} - {p.Age}",
                "age" => p => $"{p.Age}"
            };

            filtered.ForEach(p => Console.WriteLine(print(p)));
        }
    }
}

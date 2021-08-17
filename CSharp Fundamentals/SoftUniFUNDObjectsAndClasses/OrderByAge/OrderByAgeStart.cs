using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class OrderByAgeStart
    {
        static void Main()
        {
            string input = "";

            List<Person> persons = new List<Person>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ");

                string name = data[0],
                    id = data[1];
                int age = int.Parse(data[2]);

                persons.Add(new Person(name, id, age));
            }

            List<Person> result = persons.OrderBy(p => p.Age).ToList();

            foreach (var person in result)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
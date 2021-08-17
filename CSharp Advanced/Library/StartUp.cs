using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace IteratorsAndComparators
{
    class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Person> standart = new HashSet<Person>();
            SortedSet<Person> sorted = new SortedSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                if (!standart.Contains(person, new PersonComparer()))
                {
                    standart.Add(person);
                }
                sorted.Add(person);
            }

            Console.WriteLine(standart.Count);
            Console.WriteLine(sorted.Count);
        }
    }
}

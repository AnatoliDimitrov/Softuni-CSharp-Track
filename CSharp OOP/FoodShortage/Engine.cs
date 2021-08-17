using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Engine
    {
        private ICollection<Person> people;

        public Engine()
        {
            people = new List<Person>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = null;

                if (personInfo.Length == 3)
                {
                    person = new Rebel(personInfo[0], int.Parse(personInfo[1]), personInfo[2]);
                }
                else if (personInfo.Length == 4)
                {
                    person = new Citizen(personInfo[0], int.Parse(personInfo[1]), personInfo[2], personInfo[3]);
                }

                people.Add(person);
            }

            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    IBuyer buyer = (IBuyer)people.First(p => p.Name == input);

                    buyer.BuyFood();
                }
                catch (Exception)
                {

                    continue;
                }
            }

            int wholeFood = people
                .Select(p => (IBuyer)p)
                .Sum(p => p.Food);

            Console.WriteLine(wholeFood);
        }
    }
}

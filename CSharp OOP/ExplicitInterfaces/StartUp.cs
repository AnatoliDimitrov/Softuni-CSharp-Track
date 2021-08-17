using System;
using System.Runtime.InteropServices;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main()
        {
            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                string country = personInfo[1];
                int age = int.Parse(personInfo[2]);

                IResident iResident = new Citizen(name, country, age);
                IPerson iPerson = new Citizen(name, country, age);

                Console.WriteLine(iPerson.GetName());
                Console.WriteLine(iResident.GetName());
            }
        }
    }
}

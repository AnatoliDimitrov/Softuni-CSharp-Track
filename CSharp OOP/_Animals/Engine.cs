using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Animals
{
    public class Engine
    {
        private List<Animal> animals;

        public Engine()
        {
            animals = new List<Animal>();
        }
        public void Run()
        {
            string type = "";

            while ((type = Console.ReadLine()) != "Beast!")
            {
                string[] args = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal;

                try
                {
                    animal = GetAnimal(type, args);
                    animals.Add(animal);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }

            foreach (var animalItem in animals)
            {
                Console.WriteLine(animalItem);
            }
        }

        private Animal GetAnimal(string type, string[] arguments)
        {
            string name = arguments[0];
            int age = int.Parse(arguments[1]);

            Animal animal = null;

            if (type == "Dog")
            {
                animal = new Dog(name, age, arguments[2]);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, arguments[2]);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, arguments[2]);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}

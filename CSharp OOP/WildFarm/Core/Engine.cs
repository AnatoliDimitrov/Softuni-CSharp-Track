using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Cats;
using WildFarm.FoodModels;

namespace WildFarm.Core
{
    public class Engine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                string[] foodInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                Animal animal = null;

                if (type == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);

                    animal = new Owl(name, weight, wingSize);
                }
                else if (type == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);

                    animal = new Hen(name, weight, wingSize);
                }
                else if (type == "Mouse")
                {
                    string livingRegion = animalInfo[3];

                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    string livingRegion = animalInfo[3];

                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];

                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];

                    animal = new Tiger(name, weight, livingRegion, breed);
                }

                Console.WriteLine(animal.ProduceSound());
                animals.Add(animal);

                Food food = null;

                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(foodQuantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(foodQuantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(foodQuantity);
                }
                try
                {
                    animal.Feed(food);
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}

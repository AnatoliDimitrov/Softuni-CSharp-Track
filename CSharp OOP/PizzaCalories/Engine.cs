using Pizza.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            // Dough White Chewy 100
            string pizzaName = Console.ReadLine().Split()[1];

            Pizza pizza = new Pizza(pizzaName);

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {

                string[] inputInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string material = inputInfo[0].ToLower();

                if (material == "dough")
                {

                    string flourType = inputInfo[1];
                    string bakingTechnique = inputInfo[2];
                    double weight = double.Parse(inputInfo[3]);

                    Dough dough = new Dough(flourType, bakingTechnique, weight);

                    pizza.Dough = dough;
                }
                else if (material == "topping")
                {
                    string toppingType = inputInfo[1];
                    double toppingWeight = double.Parse(inputInfo[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
        }
    }
}

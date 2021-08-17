using Pizza.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            set 
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(GlobalExceptionsMessages.invalidPizzaName);
                }

                name = value; 
            }
        }

        public Dough Dough { get; set; }

        public double TotalCalories
        {
            get { return GetTotalCalories(); }
        }


        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new InvalidOperationException(GlobalExceptionsMessages.invalidCountOfToppings);
            }

            toppings.Add(topping);
        }

        private double GetTotalCalories()
        {
            return toppings
                .Sum(t => t.Calories) + Dough.Calories;
        }
    }
}

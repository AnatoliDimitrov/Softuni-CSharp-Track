using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Ingredients
{
    public class Topping
    {
        private const double MIN_WEIGHT = 1;
        private const double MAX_WEIGHT = 50;

        private string type;
        private double weight;
        private double toppingCalories;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
            this.Calories = toppingCalories;
        }

        public string Type
        {
            get { return type; }
            private set 
            { 
                type = PizzaValidator.ValidateToppingType(value); 
            }
        }

        public double Weight
        {
            get { return weight; }
            private set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(GlobalExceptionsMessages.invalidToppingWeight, this.Type));
                }
                weight = value; 
            }
        }

        public double Calories
        {
            get { return toppingCalories; }
            set { toppingCalories = GetToppingCalories(); }
        }


        private double GetToppingCalories()
        {
            return (this.Weight * PizzaModifiers.GetToppingTypeModifier(this.Type.ToLower())) * 2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pizza
{
    public static class PizzaValidator
    {
        private static Dictionary<string, double> flourType;

        private static Dictionary<string, double> bakingTechnique;

        private static Dictionary<string, double> toppingType;

        private static void Initialize()
        {
            if (flourType != null)
            {
                return;
            }

            flourType = new Dictionary<string, double>();
            bakingTechnique = new Dictionary<string, double>();
            toppingType = new Dictionary<string, double>();

            flourType.Add("white", 1.5);
            flourType.Add("wholegrain", 1.0);

            bakingTechnique.Add("crispy", 0.9);
            bakingTechnique.Add("chewy", 1.1);
            bakingTechnique.Add("homemade", 1);

            toppingType.Add("meat", 1.2);
            toppingType.Add("veggies", 0.8);
            toppingType.Add("cheese", 1.1);
            toppingType.Add("sauce", 0.9);

        }

        public static string ValidateFlourType(string type)
        {
            Initialize();

            if (!flourType.ContainsKey(type.ToLower()))
            {
                throw new ArgumentException(GlobalExceptionsMessages.invalidFlourType);
            }

            return type;
        }

        public static string ValidateBakingTechnique(string technique)
        {
            Initialize();

            if (!bakingTechnique.ContainsKey(technique.ToLower()))
            {
                throw new ArgumentException(GlobalExceptionsMessages.invalidFlourType);
            }

            return technique;
        }

        public static string ValidateToppingType(string topping)
        {
            Initialize();

            if (!toppingType.ContainsKey(topping.ToLower()))
            {
                throw new ArgumentException(string.Format(GlobalExceptionsMessages.invalidToppingType, topping));
            }

            return topping;
        }
    }
}

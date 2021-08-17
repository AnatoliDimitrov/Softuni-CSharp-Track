using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    public static class PizzaModifiers
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

        public static double GetFlourTypeModifier(string type)
        {
            Initialize();

            return flourType[type.ToLower()];
        }

        public static double GetBakingTechniqueModifier(string technique)
        {
            Initialize();

            return bakingTechnique[technique.ToLower()];
        }

        public static double GetToppingTypeModifier(string topping)
        {
            Initialize();

            return toppingType[topping.ToLower()];
        }
    }
}

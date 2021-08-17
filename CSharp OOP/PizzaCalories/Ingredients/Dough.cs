using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Ingredients
{
    public class Dough
    {
		private const double MIN_WEIGHT = 1;
		private const double MAX_WEIGHT = 200;

		private string flourType;
		private string bakingTechnique;
		private double weight;
		private double caloriesPerGram;

		public Dough(string flourType, string bakingTechnique, double weight)
		{
			this.FlourType = flourType;
			this.BakingTechnique = bakingTechnique;
			this.Weight = weight;
			this.Calories = caloriesPerGram;
		}

		public double Calories
		{
			get { return caloriesPerGram; }
			private set 
			{ 
				caloriesPerGram = GetCalories(); 
			}
		}

		public string FlourType
		{
			get { return flourType; }
			private set { flourType = PizzaValidator.ValidateFlourType(value); }
		}

		public string BakingTechnique
		{
			get { return bakingTechnique; }
			private set { bakingTechnique = PizzaValidator.ValidateBakingTechnique(value); }
		}

		public double Weight
		{
			get { return weight; }
			private set 
			{
				if (value < MIN_WEIGHT || value > MAX_WEIGHT)
				{
					throw new ArgumentException(GlobalExceptionsMessages.InvalidDoughWeight);
				}

				weight = value;
			}
		}

		private double GetCalories()
		{
			return (2 * this.Weight) * PizzaModifiers.GetFlourTypeModifier(this.FlourType) * PizzaModifiers.GetBakingTechniqueModifier(this.bakingTechnique);
		}
	}
}

using System;
using System.Collections.Generic;
using WildFarm.FoodModels;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightMultplier => 0.35;

        public override ICollection<Type> EdibleFoods => new List<Type> {typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };

        public override void Feed(Food food)
        {
            if (!this.EdibleFoods.Contains(food.GetType()))
            {
                throw new ArgumentException($"{nameof(Hen)} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultplier;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}

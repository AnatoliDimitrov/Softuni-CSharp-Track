using System;
using System.Collections.Generic;
using WildFarm.FoodModels;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultplier => 0.10;

        public override ICollection<Type> EdibleFoods => new List<Type> { typeof(Vegetable), typeof(Fruit)};

        public override void Feed(Food food)
        {
            if (!this.EdibleFoods.Contains(food.GetType()))
            {
                throw new ArgumentException($"{nameof(Mouse)} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultplier;
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}

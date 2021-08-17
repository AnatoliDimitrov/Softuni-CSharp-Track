using System;
using System.Collections.Generic;
using WildFarm.FoodModels;

namespace WildFarm.Animals.Mammals.Cats
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultplier => 1.00;

        public override ICollection<Type> EdibleFoods => new List<Type> { typeof(Meat)};

        public override void Feed(Food food)
        {
            if (!this.EdibleFoods.Contains(food.GetType()))
            {
                throw new ArgumentException($"{nameof(Tiger)} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultplier;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}

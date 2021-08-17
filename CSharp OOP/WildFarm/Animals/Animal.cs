using System;
using System.Collections.Generic;
using WildFarm.Contracts;
using WildFarm.FoodModels;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract double WeightMultplier { get; }

        public abstract ICollection<Type> EdibleFoods { get; }

        public abstract string ProduceSound();

        public abstract void Feed(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}

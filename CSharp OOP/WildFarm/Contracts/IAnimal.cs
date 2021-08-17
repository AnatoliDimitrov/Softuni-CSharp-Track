using System;
using System.Collections.Generic;
using WildFarm.FoodModels;

namespace WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        void Feed(Food food);
    }
}

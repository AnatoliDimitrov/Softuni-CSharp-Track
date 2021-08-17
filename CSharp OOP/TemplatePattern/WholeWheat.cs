using System;

namespace TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat bread (15 min).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Whole Wheat bread.");
        }

    }
}

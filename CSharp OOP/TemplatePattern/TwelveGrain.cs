using System;

namespace TemplatePattern
{
    public class TwelveGrain : Bread
    {

        public override void Bake()
        {
            Console.WriteLine("Baking the TwelveGrain bread (25 min).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for TwelveGrain bread.");
        }
    }
}

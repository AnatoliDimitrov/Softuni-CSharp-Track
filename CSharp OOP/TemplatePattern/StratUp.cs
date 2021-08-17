using System;

namespace TemplatePattern
{
    class StratUp
    {
        static void Main()
        {
            var twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            var sourdough = new Sourdough();
            sourdough.Make();

            var wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}

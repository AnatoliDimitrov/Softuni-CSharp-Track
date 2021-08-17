using System;

namespace IntegerAndRealNumbers
{
    class IntegerAndRealNumbers
    {
        static void Main()
        {
            int meters = int.Parse(Console.ReadLine());
            double kilometers = meters * 0.001;

            Console.WriteLine("{0:0.00}", kilometers);
        }
    }
}

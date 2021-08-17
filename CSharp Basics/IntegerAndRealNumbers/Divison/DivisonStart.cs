namespace Divison
{
    using System;
    class DivisonStart
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int devider = 0;

            if (input % 2 == 0)
            {
                devider = 2;
            }
            if (input % 3 == 0)
            {
                devider = 3;
            }
            if (input % 6 == 0)
            {
                devider = 6;
            }
            if (input % 7 == 0)
            {
                devider = 7;
            }
            if (input % 10 == 0)
            {
                devider = 10;
            }

            if (devider > 0 )
            {
                Console.WriteLine("The number is divisible by {0}", devider);
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}

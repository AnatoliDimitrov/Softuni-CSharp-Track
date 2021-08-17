namespace LowerOrUpper
{
    using System;
    class LowerOrUpperStart
    {
        static void Main()
        {
            char letter = Console.ReadLine()[0];

            if ((int)letter >= 65 && (int)letter <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}

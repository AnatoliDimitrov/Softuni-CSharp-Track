namespace ThirdDigit
{
    using System;

    class ThirdDigitStart
    {
        static void Main()
        {
            string integer = Console.ReadLine();

            if (integer[integer.Length - 2].CompareTo('7') == 1)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}

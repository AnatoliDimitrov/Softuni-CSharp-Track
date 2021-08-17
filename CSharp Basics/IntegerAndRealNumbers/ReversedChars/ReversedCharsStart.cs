namespace ReversedChars
{
    using System;
    class ReversedCharsStart
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            string third = Console.ReadLine();

            Console.WriteLine("{2} {1} {0}", first, second, third);
        }
    }
}

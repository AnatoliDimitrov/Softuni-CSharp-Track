using System;

namespace ReverseStrings
{
    class ReverseStringStart
    {
        static void Main()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                char[] rev = input.ToCharArray();
                Array.Reverse(rev);
                Console.WriteLine($"{input} = {String.Join("", rev)}");
            }
        }
    }
}

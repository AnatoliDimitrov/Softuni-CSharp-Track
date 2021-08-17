using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class ReverseStringsStart
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>(input.Length);

            foreach (char character in input)
            {
                stack.Push(character);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}

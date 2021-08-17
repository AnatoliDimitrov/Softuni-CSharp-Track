using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReplaceRepeatingChars
{
    class ReplaceRepeatingCharsStart
    {
        static void Main()
        {
            List<char> input = Console.ReadLine().ToCharArray().ToList();

            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    input.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join("", input));
        }
    }
}

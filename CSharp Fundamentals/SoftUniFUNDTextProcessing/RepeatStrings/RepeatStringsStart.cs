using System;
using System.Text;

namespace RepeatStrings
{
    class RepeatStringsStart
    {
        static void Main()
        {
            StringBuilder result = new StringBuilder();

            string[] input = Console.ReadLine().Split(" ");

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    result.Append(input[i]);
                }
            }

            Console.WriteLine(result);
        }
    }
}

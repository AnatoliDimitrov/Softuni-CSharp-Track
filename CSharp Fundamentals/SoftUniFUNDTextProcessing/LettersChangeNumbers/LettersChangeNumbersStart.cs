using System;
using System.Linq;

namespace LettersChangeNumbers
{
    class LettersChangeNumbersStart
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char f = input[i][0];
                char l = input[i].Last();
                double number = int.Parse(input[i].Remove(0, 1).Remove(input[i].Length - 2));;

                if (char.IsUpper(f))
                {
                    number = number / ((int)f - 64.0);
                }
                else
                {
                    number = number * ((int)f - 96.0);
                }

                if (char.IsUpper(l))
                {
                    number -= (int)l - 64.0;
                }
                else
                {
                    number += (int)l - 96.0;
                }
                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}

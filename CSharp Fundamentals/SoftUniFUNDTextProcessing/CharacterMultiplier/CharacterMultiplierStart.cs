using System;

namespace CharacterMultiplier
{
    class CharacterMultiplierStart
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            string first = input[0];
            string second = input[1];

            double totalSum = 0;

            for (int i = 0; i < (first.Length > second.Length ? first.Length : second.Length); i++)
            {
                if (i < first.Length && i < second.Length)
                {
                    totalSum += (double)first[i] * (double)second[i];
                }
                else if (i < first.Length)
                {
                    totalSum += (double)first[i];
                }
                else if (i < second.Length)
                {
                    totalSum += (double)second[i];
                }
            }

            Console.WriteLine(totalSum);
        }
    }
}

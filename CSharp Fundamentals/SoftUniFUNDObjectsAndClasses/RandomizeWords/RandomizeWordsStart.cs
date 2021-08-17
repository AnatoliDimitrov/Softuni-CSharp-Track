using System;

namespace RandomizeWords
{
    class RandomizeWordsStart
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(" ");

            Random random = new Random();

            for (int i = 0; i < words.Length - 1; i++)
            {
                int j = random.Next(i, words.Length);
                string temp = words[i];
                words[i] = words[j];
                words[j] = temp;
            }

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}

using System;

namespace TextFilter
{
    class TextFilterStart
    {
        static void Main()
        {
            string[] banned = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            for (int i = 0; i < banned.Length; i++)
            {
                text = text.Replace(banned[i], new String('*', banned[i].Length));
            }
            Console.WriteLine(text);
        }
    }
}

namespace TriplesOfLatinLetters
{
    using System;
    class TriplesOfLatinLettersStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 97; i < 97 + n; i++)
            {
                for (int j = 97; j < 97 + n; j++)
                {
                    for (int g = 97; g < 97 + n; g++)
                    {
                        Console.WriteLine("{0}{1}{2}", (char)i, (char)j, (char)g);
                    }
                }
            }
        }
    }
}

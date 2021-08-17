using System;

namespace test
{
    class Program
    {
        static void Main()
        {
            for (char i = (char)97; i <= (char)99; i++)
            {
                for (char j = (char)97; j <= (char)99; j++)
                {
                    for (char g = (char)97; g <= (char)99; g++)
                    {
                        Console.WriteLine("{0}{1}{2}", i, j, g);
                    }
                }
            }
        }
    }
}

namespace PokeMon
{
    using System;
    class PokeMonStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            decimal half = n / 2.0m;
            int counter = 0;

            while (n >= m)
            {
                if (n == half)
                {
                    if (y > 0)
                    {
                        n /= y;
                    }
                    
                    if (n < m)
                    {
                        break;
                    }
                }
                n -= m;
                counter++;
            }
            Console.WriteLine(n);
            Console.WriteLine(counter);
        }
    }
}

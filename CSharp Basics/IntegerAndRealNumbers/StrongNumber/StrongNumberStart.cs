namespace StrongNumber
{
    using System;
    class StrongNumberStart
    {
        static void Main()
        {
            string n = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < n.Length; i++)
            {
                int digit = int.Parse(n[i].ToString());
                int fact = 1;
                for (int j = 1; j <= digit; j++)
                {
                    fact *= j;  
                }
                sum += fact;
            }

            if (sum == int.Parse(n))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}

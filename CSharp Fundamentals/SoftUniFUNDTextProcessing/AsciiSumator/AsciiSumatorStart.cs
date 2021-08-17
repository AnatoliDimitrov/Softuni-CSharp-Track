using System;
using System.Text;

namespace AsciiSumator
{
    class AsciiSumatorStart
    {
        static void Main()
        {
            int start = (int)char.Parse(Console.ReadLine());
            int end = (int)char.Parse(Console.ReadLine());
            string someString = Console.ReadLine();

            if (start < end)
            {
                Print(start, end, someString);
            }
            else
            {
                Print(end, start, someString);
            }
        }

        static void Print(int start, int end, string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int temp = (int)str[i];
                if (temp > start && temp < end)
                {
                    sum += temp;
                }
            }
            Console.WriteLine(sum);
        }
    }
}

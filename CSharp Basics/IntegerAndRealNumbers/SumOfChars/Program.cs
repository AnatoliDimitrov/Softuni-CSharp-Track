namespace SumOfChars
{
    using System;
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());
                sum += (int)input;
            }
            Console.WriteLine("The sum equals: {0}", sum);
        }
    }
}

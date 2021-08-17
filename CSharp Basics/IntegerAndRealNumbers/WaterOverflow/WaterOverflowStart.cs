namespace WaterOverflow
{
    using System;
    class WaterOverflowStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (sum + input > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sum += input;
                }

            }
            Console.WriteLine(sum);
        }
    }
}

namespace MultiplicationTable2._0
{
    using System;
    class MultiplicationTable2
    {
        static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());


            if (second > 10)
            {
                Console.WriteLine("{0} X {1} = {2}", first, second, first * second);
            }
            else
            {
                for (int i = second; i <= 10; i++)
                {
                    Console.WriteLine("{0} X {1} = {2}", first, i, first * i);
                }
            }
        }
    }
}

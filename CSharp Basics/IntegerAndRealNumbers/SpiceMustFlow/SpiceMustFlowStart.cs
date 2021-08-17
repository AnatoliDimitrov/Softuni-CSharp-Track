namespace SpiceMustFlow
{
    using System;
    class SpiceMustFlowStart
    {
        static void Main()
        {
            int firstDay = int.Parse(Console.ReadLine());
            int totalSpice = 0,
                counter = 0;

            while (firstDay >= 100)
            {
                totalSpice += firstDay;
                totalSpice -= 26;
                firstDay -= 10;
                counter++;
            }
            if (totalSpice >= 26)
            {
                totalSpice -= 26;
            }
            Console.WriteLine(counter);
            Console.WriteLine(totalSpice);
        }
    }
}

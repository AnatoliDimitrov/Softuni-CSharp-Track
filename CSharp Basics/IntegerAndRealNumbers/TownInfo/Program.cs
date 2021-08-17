namespace TownInfo
{
    using System;
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            short area = short.Parse(Console.ReadLine());

            Console.WriteLine("Town {0} has population of {1} and area {2} square km.", name, population, area);
        }
    }
}

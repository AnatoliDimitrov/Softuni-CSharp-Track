namespace Knights_ofHonor
{
    using System;
    using System.Linq;

    class KnightsOfHonor
    {
        static void Main()
        {
            var knights = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> addSir = k => Console.WriteLine("Sir " + k);

            knights
                .ForEach(addSir);
        }
    }
}

namespace PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PredicateForNamesStart
    {
        static void Main()
        {
            int len = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> predicate = new Predicate<string>(n => n.Length <= len);

            names
                .Where(n => predicate(n))
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}

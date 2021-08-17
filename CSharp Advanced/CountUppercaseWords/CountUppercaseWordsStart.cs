using System;
using System.Linq;

namespace CountUppercaseWords
{
    class CountUppercaseWordsStart
    {
        static void Main()
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}

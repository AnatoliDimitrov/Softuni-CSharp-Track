namespace ReverseAndExclude
{
    using System;
    using System.Linq;

    class ReverseAndExcludeStart
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int delimeter = int.Parse(Console.ReadLine());

            Action<string> Print = Console.Write;

            Func<int, bool> predicate = new Func<int, bool>(n => n % delimeter != 0);

            numbers
                .Where(predicate)
                .Reverse()
                .ToList()
                .ForEach(n => Console.Write(n + " "));
        }
    }
}

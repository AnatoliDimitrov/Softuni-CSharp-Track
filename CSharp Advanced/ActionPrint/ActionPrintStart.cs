namespace ActionPrint
{
    using System;
    using System.Linq;
    class ActionPrintStart
    {
        static void Main()
        {
            Action<string> Print = Console.WriteLine;

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            names.ForEach(p => Print(p));
        }
    }
}

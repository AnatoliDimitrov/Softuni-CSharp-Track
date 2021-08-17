namespace AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class AppliedArithmeticsStart
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {

                if (input != "print")
                {
                    Func<int, int> math = Arithmetics(input);

                    nums = nums
                        .Select(math)
                        .ToArray();
                }
                else
                {
                    Console.WriteLine(string.Join(" ", nums));
                }
            }
        }

        static Func<int, int> Arithmetics(string arithmetic)
        {
            return arithmetic switch 
            {
                "add" => new Func<int, int>(n => n = n + 1),
                "multiply" => new Func<int, int>(n => n * 2),
                "subtract" => new Func<int, int>(n => n = n-1)
            };
        }
    }
}

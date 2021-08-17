namespace BalancedBrackets
{
    using System;
    class BalancedBracketsStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int LeftBrackets = 0;
            int rightBrackets = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    LeftBrackets++;
                }
                else if (input == ")")
                {
                    rightBrackets++;
                }

                if (rightBrackets > LeftBrackets)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
            }
            if (LeftBrackets == rightBrackets)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}

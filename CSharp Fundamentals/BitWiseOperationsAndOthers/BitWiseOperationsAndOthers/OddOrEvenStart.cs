namespace BitWiseOperationsAndOthers
{
    using System;
    class OddOrEvenStart
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            if (num % 2 == 0)
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }
        }
    }
}

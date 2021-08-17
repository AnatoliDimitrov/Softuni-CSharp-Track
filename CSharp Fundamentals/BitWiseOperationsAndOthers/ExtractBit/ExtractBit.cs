namespace ExtractBit
{
    using System;
    class ExtractBit
    {
        static void Main()
        {
            int i = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int mask = 1 << b;
            int result = mask & i;
            result >>= b;

            Console.WriteLine(result);
        }
    }
}

namespace FindThirdBit
{
    using System;
    class FindThirdBitStart
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            bool bit = false;
            int bitCount = 3;
            int mask = 1 << bitCount;

            int res = num & mask;
            res = res >> bitCount;

            if (res == 1)
            {
                bit = true;
            }

            Console.WriteLine(Convert.ToString(num, 2)) ;
            Console.WriteLine(bit);

        }
    }
}

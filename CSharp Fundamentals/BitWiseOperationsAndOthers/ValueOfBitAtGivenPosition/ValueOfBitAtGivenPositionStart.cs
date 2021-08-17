namespace ValueOfBitAtGivenPosition
{
    using System;
    class ValueOfBitAtGivenPositionStart
    {
        static void Main()
        {
            int v = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int mask = 1 << p;
            int result = v & mask;
            result >>= p;

            //Console.WriteLine(Convert.ToString(v, 2));
            //Console.WriteLine(result);

            bool isOne = false;

            if (result == 1)
            {
                isOne = true;
            }

            Console.WriteLine(isOne);

        }
    }
}

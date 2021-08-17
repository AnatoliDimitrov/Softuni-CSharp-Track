namespace AssignBit
{
    using System;
    class AssignBit
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int mask = 1 << p;
            int result;

            if (v == 1)
            {
                result = mask | n;
            }
            else
            {
                result = mask ^ n;
            }

            Console.WriteLine(result);
        }
    }
}

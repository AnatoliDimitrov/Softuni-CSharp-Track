namespace ConcatNames
{
    using System;
    class ConcatNamesStart
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string last = Console.ReadLine();
            string delimeter = Console.ReadLine();

            Console.WriteLine("{0}{1}{2}", first, delimeter, last);
        }
    }
}

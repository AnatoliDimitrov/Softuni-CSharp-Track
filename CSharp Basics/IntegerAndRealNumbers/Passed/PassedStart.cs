using System;

namespace Passed
{
    class PassedStart
    {
        static void Main()
        {
            float grade = float.Parse(Console.ReadLine());

            if (grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}

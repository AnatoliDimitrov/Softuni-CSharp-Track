namespace PassedOrFailed
{
    using System;
    class PassedOrFailedStart
    {
        static void Main()
        {
            float grade = float.Parse(Console.ReadLine());

            if (grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}

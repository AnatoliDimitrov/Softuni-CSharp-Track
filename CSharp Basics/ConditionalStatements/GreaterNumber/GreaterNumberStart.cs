namespace GreaterNumber
{
    using System;
    class GreaterNumberStart
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber < secondNumber)
            {
                firstNumber = secondNumber;
            }
            Console.WriteLine(firstNumber);
        }
    }
}

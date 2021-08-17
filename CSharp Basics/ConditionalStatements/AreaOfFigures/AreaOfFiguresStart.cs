namespace AreaOfFigures
{
    using System;
    class AreaOfFiguresStart
    {
        static void Main()
        {
            string shape = Console.ReadLine();
            double firstNumber = 0.0;
            double secondNumber = 0.0;

            if (shape == "square" || shape == "circle")
            {
                firstNumber = double.Parse(Console.ReadLine());
            }
            else
            {
                firstNumber = double.Parse(Console.ReadLine());
                secondNumber = double.Parse(Console.ReadLine());
            }

            if (shape == "square")
            {
                Console.WriteLine("{0:0.000}",firstNumber * firstNumber);
            }
            else if (shape == "rectangle")
            {
                Console.WriteLine("{0:0.000}", firstNumber * secondNumber);
            }
            else if (shape == "circle")
            {
                Console.WriteLine("{0:0.000}", Math.PI * (firstNumber * firstNumber));
            }
            else
            {
                Console.WriteLine("{0:0.000}", firstNumber / 2 * secondNumber);
            }
        }
    }
}
